using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitHandler : MonoBehaviour
{
    public List<string> PosTraits; // { "Energetic", "Assertive", "Strong", "Calm", "Informative", "Resilient", "Loyal", "Normal" };
    public List<string> NegTraits; // { "Clumsy", "Aggressive", "Stubborn", "Dishonest", "Timid" };

	public List<string> CultistTraits = new List<string>();

    public float itemFindMulti = 1f;

    public float Time_Search = 1f;
    public float Time_ActionBuffer = 1f;
    public float Time_PossessionSpeed = 1f;

    public float Chance_ExtraItems = 0.5f;
    public float Chance_ChangeRoom = 1f;
    public float Chance_SeeSomething = 1f;

    public bool Can_BePossessed = true;
    public bool Can_GetExtraItems = false;

    void Start()
    {
        PosTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().PosTraits;
        NegTraits = GameObject.Find("RuntimeScripts").GetComponent<GameBuilder>().NegTraits;
    }

    public void UpdateTraits()
	{
        foreach(string trait in CultistTraits)
        {
			switch (trait)
			{
                case "Energetic":
                    Chance_ChangeRoom += 2f;
                    Time_Search *= 0.7f;
                    Time_ActionBuffer *= 0.6f;
                    break;
                case "Assertive":
                    Chance_SeeSomething += 2f;
                    break;
                case "Strong":
                    Can_GetExtraItems = true;
                    Chance_ExtraItems += 0.5f;
                    break;
                case "Calm":
                    break;
                case "Informative":
                    break;
                case "Resilient":
                    Time_PossessionSpeed *= 0.5f;
                    break;
                case "Loyal":
                    Can_BePossessed = false;
                    break;
                case "Normal":
                    break;
                case "Clumsy":
                    break;
                case "Aggressive":
                    break;
                case "Stubborn":
                    break;
                case "Dishnonest":
                    break;
                case "Timid":
                    break;
                case "Temp1":
                    break;
                case "Temp2":
                    break;
                case "Temp3":
                    break;
                case "Temp4":
                    break;
                case "Temp5":
                    break;
                case "Temp6":
                    break;
                case "Temp7":
                    break;
            }
		}
	}

    void Update()
    {
        
    }
}
