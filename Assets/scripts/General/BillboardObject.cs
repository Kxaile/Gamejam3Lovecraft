using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardObject : MonoBehaviour
{
    private Camera aCam;
    // Start is called before the first frame update
    void Start()
    {
        aCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(aCam.transform);
        transform.localEulerAngles += new Vector3(0, 180, 0);
    }
}
