using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Nyarlathoteph : MonoBehaviour
{
    public GameObject cultist;
    public B_Normal baseScript;

    // Start is called before the first frame update
    void Start()
    {
        cultist = this.gameObject;
        baseScript = cultist.GetComponent<B_Normal>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
