using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scuttle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalZ(this.gameObject, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != new Vector3(0, 0, 0))
		{
            this.transform.localEulerAngles = new Vector3(0, 0, -this.transform.localEulerAngles.z);
		} else
		{
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
