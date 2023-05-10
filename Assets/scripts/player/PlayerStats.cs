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
    public float T_Insanity = 0.03f; // How often insanity is lost
    public float T_Chaos = 1f; // How often chaos is gained
    public float CT_Insanity = 0; // Used for the insanity ticks
    public float CT_Chaos = 0; // Used for the chaos ticks

    [Header("Multipliers")]
    public float base_ILM = 1f; // Default sanity loss multiplier
    public float Multi_IL = 1f; // Insanity Loss Multiplier - Set from start menu, default here
    public float Multi_chaos = 1f; // Multiplier for chaos increase rate - Set from start menu, default here

    [Header("Candles")]
    public GameObject candleParent;
    public bool Candle1 =true;
    public bool Candle2 =true;
    public bool Candle3 =true;
    public bool candle4 =true;

    
    

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
            AkSoundEngine.SetRTPCValue("Sanity", Sanity);
        }

        if (CT_Chaos >= T_Chaos / gameData.chaosGainRate)
        {
            Chaos += chaosGain * gameData.chaosGainRate;
            CT_Chaos = 0;
        }

        if (Sanity <= 75 && Candle1) 
        {
            Candle1 = false;
            candleParent.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            AkSoundEngine.PostEvent("Candle_extinguished",candleParent);
        }
        if (Sanity <= 50 && Candle2)
        {
            Candle2 = false;
            candleParent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
            AkSoundEngine.PostEvent("Candle_extinguished", candleParent);
        }
        if (Sanity <=25 && Candle3)
        {
            Candle3 = false;
            candleParent.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
            AkSoundEngine.PostEvent("Candle_extinguished", candleParent);
        }
        if (Sanity <= 0 && candle4)
        {
            candle4 = false;
            candleParent.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            AkSoundEngine.PostEvent("Candle_extinguished", candleParent);
        }
    }
}
