using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaker : MonoBehaviour
{
    [Header("Slider Stats")]

    public int numOfCultists = 6;
    public int numOfRituals = 5;
    public float maxSanity = 100f;

    public float sanityLossRate = 1f; // Multiplier for sanity
    public float chaosGainRate = 1f; // Multiplier for Chaos

    [Header("Drop Down Options Indexes")]

    public int i_amountOfResources = 1;
    public int i_evilType = 0;

    [Header("Drop Down Options")]

    public List<string> Evils = new List<string>() {"Kassogtha", "Nyarlathoteph", "Golonac", "Shoggoth", "Azathoth"};
    public List<string> Resources = new List<string>() { "Little", "Normal", "Lots", "Plentiful", "bro ur playing creative now" }; // little, -1 from all resources, lots +1, plentiful +2, +3 for last


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
