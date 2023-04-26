using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitHandler : MonoBehaviour
{
    public List<string> PosTraits; // { "Energetic", "Assertive", "Strong", "Calm", "Informative", "Resilient", "Loyal", "Normal" };
    public List<string> NegTraits; // { "Clumsy", "Aggressive", "Stubborn", "Dishonest", "Timid" };

	public List<string> CultistTraits = new List<string>();

    //public float itemFindMulti = 1f;

    //public float Time_Search = 1f;
    //public float Time_ActionBuffer = 1f;
    //public float Time_PossessionSpeed = 1f;

    public int Mentality;
    public int Faith;
    public int Perception;

    public float Chance_ExtraItems = 1f;
    public float Chance_ChangeRoom = 1f;
    public float Chance_SeeSomething = 1f;

    public bool Can_BePossessed = true;

    public int Questions = 3;
    public bool isEvil = false;

    public int age;
    //public bool Can_GetExtraItems = false;

    void Start()
    {
        PosTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().PosTraits;
        NegTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().NegTraits;
    }

    void Update()
    {
        
    }
}
