using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cultistTalking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCultist(GameObject culty)
	{
        cultistTalking = culty;
	}

    public void showObsidian()
	{

        //play animation

		if (cultistTalking.GetComponent<B_Golonac>())
		{
            cultistTalking.GetComponent<B_Golonac>().sweat();
        } else
		{

        }
	}



}
