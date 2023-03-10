using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public float Sanity = 100; // Set from start menu, default here
    public int Rituals = 5; // Set from start menu, default here
    public float Chaos = 0; // Rate of which things are happening (Is used as a multiplier)
    public float maxSanity = 100f; // Set from start menu, default here

    [Header("Player Behind Scenes")] 
    public float chaosGain = 0.01f; // The amount of Chaos gained per tick
    public float insanityGain = 0.001f; // The amount of Sanity that is lost every tick
    public gameStartOptions gameData;

    [Header("Tick Events")]
    public float T_Insanity = 1f; // How often insanity is lost
    public float T_Chaos = 1f; // How often chaos is gained
    public float CT_Insanity = 0; // Used for the insanity ticks
    public float CT_Chaos = 0; // Used for the chaos ticks

    [Header("Multipliers")]
    public float base_ILM = 1f; // Default sanity loss multiplier
    public float Multi_IL = 1f; // Insanity Loss Multiplier - Set from start menu, default here
    public float Multi_chaos = 1f; // Multiplier for chaos increase rate - Set from start menu, default here

    [Header("Candles")]
    public GameObject candleParent;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("RuntimeScripts").GetComponent<gameStartOptions>();
        maxSanity = gameData.maxSanity;
        Rituals = gameData.numOfRituals;

    }

    // Update is called once per frame
    void Update()
    {
        CT_Insanity += Time.deltaTime;
        CT_Chaos += Time.deltaTime;

        if (CT_Insanity >= T_Insanity / gameData.sanityLossRate)
        {
            Sanity -= insanityGain * gameData.sanityLossRate;
            CT_Insanity = 0;
        }

        if (CT_Chaos >= T_Chaos / gameData.chaosGainRate)
        {
            Chaos += chaosGain * gameData.chaosGainRate;
            CT_Chaos = 0;
        }

        switch (Sanity)
        {
            case 75f:
                candleParent.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 50f:
                candleParent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 25f:
                candleParent.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 0f:
                candleParent.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
            
    }
}
