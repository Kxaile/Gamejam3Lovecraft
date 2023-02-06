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

    private List<string> Rooms;
    private GameObject RoomUI;
    
    // Start is called before the first frame update
    void Start()
    {
        CultName = this.gameObject.name;
        Age = Random.Range(16, 50);
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<CreateCultists>().Rooms;
        Room = Rooms[Random.Range(0, Rooms.Count)];
        RoomUI = GameObject.Find("MinimapTemp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
