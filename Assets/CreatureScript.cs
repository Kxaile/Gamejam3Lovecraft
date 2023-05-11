using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public float MaxStare;
    public float currentStare;
    public PlayerStats GetChaos;
    public NewCamScript camScript;
    private float position;
    public float Gain;


    void Awake()
    {
        GetChaos = GameObject.FindWithTag("RuntimeScripts").GetComponent<PlayerStats>();

        camScript = GameObject.FindWithTag("MainCamera").GetComponent<NewCamScript>();

        GetChaos.insanityGain += Gain;

        LeanTween.rotate(transform.parent.Find("Door").gameObject, transform.parent.Find("DoorEnd").eulerAngles, 1f);
        LeanTween.move(transform.parent.Find("Door").gameObject, transform.parent.Find("DoorEnd").position, 1f);

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

            else if (gameObject.transform.parent.name == "Right")
            {
                GetChaos.transform.GetComponent<QTE_Call>().CreatureRight = false;
            }

            else if (gameObject.transform.parent.name == "Up")
            {
                GetChaos.transform.GetComponent<QTE_Call>().CreatureUp = false;
            }

            if (!GetChaos.transform.GetComponent<QTE_Call>().HasDefeatedCreature)
            {
                GetChaos.transform.GetComponent<QTE_Call>().HasDefeatedCreature = true;
                camScript.Tutorial.gameObject.SetActive(false);
            }
            LeanTween.rotate(transform.parent.Find("Door").gameObject, transform.parent.Find("DoorStart").eulerAngles, 0.2f);
            LeanTween.move(transform.parent.Find("Door").gameObject, transform.parent.Find("DoorStart").position, 0.2f);
            Destroy(this.gameObject);
            
        }
        if (currentStare > 0)
        {

        }
    }
}
