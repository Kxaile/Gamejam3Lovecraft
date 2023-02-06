using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Shoggoth : MonoBehaviour
{

    public string CultName;
    public string Room;

    private List<string> Rooms;

    public int Age;

    // Start is called before the first frame update
    void Start()
    {
        CultName = this.gameObject.name;
        Age = Random.Range(16, 50);
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<CreateCultists>().Rooms;
        Room = Rooms[Random.Range(0, Rooms.Count)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
