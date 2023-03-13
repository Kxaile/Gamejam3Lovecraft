using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpiesD : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-4, 5);
        y = Random.Range(-4, 5);
        z = Random.Range(-4, 5);
}

    
    // Update is called once per frame
    void Update()
    {
        //transform.localEulerAngles += new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
        transform.rotation *= Quaternion.Euler(x/5, y/1, z/5);

        if (transform.position.y < 0)
		{
            transform.GetComponent<Rigidbody>().velocity *= -1;
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
            transform.localScale = new Vector3(Random.Range(0f, 5f), Random.Range(0f, 5f), Random.Range(0f, 5f));
        }
    }
}
