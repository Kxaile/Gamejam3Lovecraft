using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactables : MonoBehaviour
{
    public GameObject LastHit;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast( ray , out hit , 25f , mask ))
        {

            

            LastHit = hit.transform.gameObject;
            print(LastHit.name);
            
            
        }
    }
}


