using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CallScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject runtimeHolder;
    public GameObject cultist;
    public TMP_Text diaryLog;
    public CultInteracting cultCaller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callCultist()
	{
        print("He is coming");
        runtimeHolder = GameObject.Find("RuntimeScripts");
        cultCaller = runtimeHolder.GetComponent<CultInteracting>();
        cultCaller.AttemptCall(cultist);
	}
}
