using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Call : MonoBehaviour
{
    public GameObject PositionParent;
    public GameObject QTEPrefab;
    public PlayerStats Getchaos;
    public NewCamScript camScript;
    public float chaosMultiplier = 1f;
    private float Check;
    public bool CreatureLeft, CreatureRight, CreatureUp = false;
    public bool HasDefeatedCreature = false;


    // Start is called before the first frame update
    void Start()
    {
        Getchaos = this.gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Check = Random.Range(0f, 10000f - Getchaos.Chaos *chaosMultiplier);
        
        if(Check >= 1 && Check <=2  && !CreatureLeft)
        {
            StartQTE(PositionParent.transform.GetChild(0).gameObject);
            CreatureLeft = true;
            Debug.Log("creature left");
            camScript.LeftCreature = PositionParent.transform.GetChild(0).transform.GetChild(0).gameObject;

        }
        if(Check >= 10 && Check <= 11 && !CreatureRight)
        {
            StartQTE(PositionParent.transform.GetChild(1).gameObject);
            CreatureRight = true;
            Debug.Log("creature right");
            camScript.RightCreature = PositionParent.transform.GetChild(1).transform.GetChild(0).gameObject;
        }
        if (Check >= 20 && Check <= 21 && !CreatureUp)
        {
            StartQTE(PositionParent.transform.GetChild(2).gameObject);
            CreatureUp = true;
            Debug.Log("creature up");
            camScript.UpCreature = PositionParent.transform.GetChild(2).transform.GetChild(0).gameObject;
        }
    }

    void StartQTE(GameObject Position)
    {
         Instantiate(QTEPrefab, Position.transform);
        
    }
    
}
