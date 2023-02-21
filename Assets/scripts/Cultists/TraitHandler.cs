using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitHandler : MonoBehaviour
{
    public List<string> PosTraits; // { "Energetic", "Assertive", "Strong", "Calm", "Informative", "Resilient", "Loyal", "Normal" };
    public List<string> NegTraits; // { "Clumsy", "Aggressive", "Stubborn", "Dishonest", "Timid" };

	public List<string> CultistTraits = new List<string>();

    public float itemFindMulti = 1f;
    public float SearchMulti = 1f;
    public float ExtraItemsChanceMulti = 1f;
    public float ChangeRoomMulti = 1f;
    public float SeeSomethingMulti = 1f;
    public float TimeBetweenActionsMulti = 1f;

    void Start()
    {
        PosTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().PosTraits;
        NegTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().NegTraits;
    }

    void Update()
    {
        
    }
}
