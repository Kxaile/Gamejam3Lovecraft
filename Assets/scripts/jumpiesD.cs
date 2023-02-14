using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpiesD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0)
		{
            transform.GetComponent<Rigidbody>().velocity *= -1;
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);

        }
    }
}
