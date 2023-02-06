using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Shoggoth : MonoBehaviour
{

    public string CultName;
    public int Age;
    public string Room;

    private List<string> Rooms;
    private GameObject RoomUI;

    // Start is called before the first frame update
    void Start()
    {
        CultName = this.gameObject.name;
        Age = Random.Range(16, 50);
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().Rooms;
        Room = Rooms[Random.Range(0, Rooms.Count)];

        // TEMP FOR TESTING

        RoomUI = GameObject.Find("MinimapTemp").transform.Find("Background").Find(Room).Find("CultistIconHolder").gameObject;
        GameObject icon = Instantiate(Resources.Load("SusIcon")) as GameObject;
        icon.name = CultName;
        icon.transform.SetParent(RoomUI.transform);
        icon.transform.localPosition += new Vector3(0, 0, -6);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
