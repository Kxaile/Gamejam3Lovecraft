using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactables : MonoBehaviour
{
    public GameObject LastHit;
    public LayerMask mask;
    public bool Highlighted;
    public LookScript camerascript;
  

    // Start is called before the first frame update
    void Start()
    {
        LastHit = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (camerascript.LookingDown)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Highlighted && Input.GetKeyDown(KeyCode.Mouse0))
            {
                // Interact
                print("you clicked the " + LastHit.name);
            }

            if (Physics.Raycast(ray, out hit, 25f, mask) && LastHit == null)
            {
                // highlight object
                hit.transform.GetChild(0).gameObject.SetActive(true);

                Highlighted = true;

                LastHit = hit.transform.gameObject;
                print("hovering");
                return;
            }
            else if (!(Physics.Raycast(ray, out hit, 25f, mask)) && LastHit != null)
            {
                // unhighlight object
                LastHit.transform.GetChild(0).gameObject.SetActive(false);

                Highlighted = false;

                LastHit = null;
                print("hovering stopped");
                return;
            }
            if (Physics.Raycast(ray, out hit, 25f, mask) && Highlighted == true)
            {
                if (hit.transform.gameObject != LastHit)
                {
                    LastHit.transform.GetChild(0).gameObject.SetActive(false);
                    hit.transform.GetChild(0).gameObject.SetActive(true);

                    LastHit = hit.transform.gameObject;

                }
            }
        }
    }
}


