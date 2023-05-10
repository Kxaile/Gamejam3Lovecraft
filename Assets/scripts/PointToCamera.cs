using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToCamera : MonoBehaviour
{
    public Transform Target;

    private void Awake()
    {
        Target = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target!= null)
        {
            transform.LookAt(Target);
        }
        else
        {
            print("no Target");
        }


    }
}
