using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    [Header("Player Stats")]
    public float Sanity = 100; // Set from start menu, default here
    public int Rituals = 5; // Set from start menu, default here
    public float Chaos = 0; // Rate of which things are happening (Is used as a multiplier)
    public float maxSanity = 100f; // Set from start menu, default here

    [Header("Player Behind Scenes")] 
    public float chaosGain = 1f; // The amount of Chaos gained per tick
    public float insanityGain = 0.001f; // The amount of Sanity that is lost every tick

    [Header("Tick Events")]
    public float T_Insanity = 1f; // How often insanity is lost
    public float T_Chaos = 1f; // How often chaos is gained
    public float CT_Insanity = 0; // Used for the insanity ticks
    public float CT_Chaos = 0; // Used for the chaos ticks

    [Header("Multipliers")]
    public float base_ILM = 1f; // Default sanity loss multiplier
    public float Multi_IL = 1f; // Insanity Loss Multiplier - Set from start menu, default here
    public float Multi_chaos = 1f; // Multiplier for chaos increase rate - Set from start menu, default here

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CT_Insanity += Time.deltaTime;
        CT_Chaos += Time.deltaTime;

        if (CT_Insanity >= T_Insanity)
        {
            Sanity -= insanityGain;
            CT_Insanity = 0;
        }

        if (CT_Chaos >= T_Chaos)
        {
            Chaos += chaosGain;
            CT_Chaos = 0;
        }
    }
}
