using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityScript : MonoBehaviour
{

    public float insanity;
    public float timePerTick;
    public float currentTime;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        insanity = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timePerTick)
        {
            insanity -= rate;
            currentTime = 0;
        }
        print(insanity);
    }
}
