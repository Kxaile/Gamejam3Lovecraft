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
        LastHit = null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 25f, mask) && LastHit == null)
        {
                // highlight object
                hit.transform.GetChild(0).gameObject.SetActive(true);

                LastHit = hit.transform.gameObject;
                print("hovering");
            return;
        }
        else if(!(Physics.Raycast(ray, out hit,25f,mask)) && LastHit != null)
        {
                // unhighlight object
                LastHit.transform.GetChild(0).gameObject.SetActive(false);
                

                LastHit = null;
                print("hovering stopped");
        }
    }
}


