using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public float MaxStare;
    public float currentStare;
    public PlayerStats GetChaos;
    public float Gain;


    void Awake()
    {
        GetChaos = GameObject.FindWithTag("RuntimeScripts").GetComponent<PlayerStats>();
        
        GetChaos.insanityGain += Gain;
        
    }

    void Update()
    {
        
        if (currentStare >= MaxStare)
        {
            GetChaos.insanityGain -= Gain;

            if (gameObject.transform.parent.name == "Left")
            {
                GetChaos.transform.GetComponent<QTE_Call>().CreatureLeft = false;
            }
            if (gameObject.transform.parent.name == "Right")
            {
                GetChaos.transform.GetComponent<QTE_Call>().CreatureRight = false;
            }
            if (gameObject.transform.parent.name == "Up")
            {
                GetChaos.transform.GetComponent<QTE_Call>().CreatureUp = false;
            }

            Destroy(this.gameObject);
        }
    }
}
