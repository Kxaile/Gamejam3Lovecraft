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

    public float timeSinceLastAction = 0;

    private List<string> Rooms;
    private GameObject RoomUI;

    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        CultName = this.gameObject.name;
        Age = Random.Range(16, 50);
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().Rooms;
        Room = Rooms[Random.Range(0, Rooms.Count)];

        // TEMP FOR TESTING

        RoomUI = GameObject.Find("MinimapTemp").transform.Find("Background").Find(Room).Find("CultistIconHolder").gameObject;
        icon = Instantiate(Resources.Load("CultistIcon")) as GameObject;
        icon.name = CultName;
        icon.transform.SetParent(RoomUI.transform);
        icon.transform.localPosition += new Vector3(0, 0, -6);
    }
    
    public void ChangeRoom(GameObject iconToMove)
	{
        Room = Rooms[Random.Range(0, Rooms.Count)];
        RoomUI = GameObject.Find("MinimapTemp").transform.Find("Background").Find(Room).Find("CultistIconHolder").gameObject;
        icon.transform.SetParent(RoomUI.transform);
    }


    // Update is called once per frame
    void Update()
    {
        
        timeSinceLastAction += Time.deltaTime;

        // CHANGING ROOM // 
        
        if(timeSinceLastAction > 15f && Random.Range(1,3000) == 1) // 1/5000 chance to change room every tick
		{
            ChangeRoom(icon);
            timeSinceLastAction = 0f;
		}
    }
}
