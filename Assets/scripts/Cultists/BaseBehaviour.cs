using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class B_Normal : MonoBehaviour
{

    public string CultName;
    public int Age;
    public string Room;
    public List<string> Traits;
    public Vector2 RoomCoords;

    public float timeSinceLastAction = 0;

    public TraitHandler traits;

    private List<string> Rooms;
    private GameObject RoomUI;

    public GameObject icon;
    // Start is called before the first frame update
    public void setRoom(Vector2 pos)
	{
        if (pos.y == 0)
        {
            Room = "Attic";
        }
        else if (pos.x == 1)
        {
            Room = "Hallway";
        }

        if (pos == new Vector2(0, 1))
        {
            Room = "Kitchen";
        }
        if (pos == new Vector2(0, 2))
        {
            Room = "Observatory";
        }
        if (pos == new Vector2(2, 1))
        {
            Room = "Library";
        }
        if (pos == new Vector2(2, 2))
        {
            Room = "Bedrooms";
        }
    }

    void Start()
    {
        CultName = this.gameObject.name;
        Age = Random.Range(16, 50);
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().Rooms;

        RoomCoords = new Vector2(Random.Range(0, 3), Random.Range(0, 3));

        setRoom(RoomCoords);
        traits = GetComponent<TraitHandler>();

        // TEMP FOR TESTING

        RoomUI = GameObject.Find("MinimapTemp").transform.Find("Background").Find(Room).Find("CultistIconHolder").gameObject;
        icon = Instantiate(Resources.Load("CultistIcon")) as GameObject;
        icon.name = CultName;
        icon.transform.SetParent(RoomUI.transform);
        icon.transform.localPosition += new Vector3(0, 0, -6);
    }
    
    public void ChangeRoom(GameObject iconToMove)
	{
        Vector2 NewCoords = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) + RoomCoords;
        while (NewCoords == RoomCoords && NewCoords.x < 0 && NewCoords.y < 0)
		{
            NewCoords = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) + RoomCoords;
        }

        RoomCoords = NewCoords;
        setRoom(RoomCoords);

        // testing
        RoomUI = GameObject.Find("MinimapTemp").transform.Find("Background").Find(Room).Find("CultistIconHolder").gameObject;
        icon.transform.SetParent(RoomUI.transform);
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceLastAction += Time.deltaTime;
        int chanceChangeRoom = Mathf.Clamp(Mathf.FloorToInt(3000 / traits.Chance_ChangeRoom), 2, 6000);
        int timeBetweenRooms = Mathf.Clamp(Mathf.FloorToInt(15 * traits.Time_ActionBuffer), 1, 60);

        // CHANGING ROOM // 
        if (timeSinceLastAction > timeBetweenRooms && Random.Range(1, chanceChangeRoom) == 1) // chance to change room every tick
		{
            ChangeRoom(icon);
            timeSinceLastAction = 0f;
		}
    }
}
