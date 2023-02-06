using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMap : MonoBehaviour
{
    // Start is called before the first frame update

    public List<string> Rooms;

    void Start()
    {
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().Rooms;

        foreach(string room in Rooms)
		{
            GameObject Map = GameObject.Find("MinimapTemp").transform.GetChild(0).gameObject;
            GameObject roomTemp = Instantiate(Resources.Load("UIBase")) as GameObject;
            roomTemp.transform.Find("Title").GetComponent<Text>().text = room;
            roomTemp.name = room;
            roomTemp.transform.SetParent(Map.transform);
            roomTemp.transform.localPosition += new Vector3(0, 0, -6);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
