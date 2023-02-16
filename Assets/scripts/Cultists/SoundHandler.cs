using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public List<string> Rooms;

    //public List<string> Rooms = new List<string> { "Kitchen", "Attic", "Hallway", "Bedrooms", "Office", "Library", "Observatory" };

    // Start is called before the first frame update
    void Start()
    {
        Rooms = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().Rooms;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // 0  will pick a random sounds, 1 - how many will be for specific sounds



}
