using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultInteracting : MonoBehaviour
{
    // Start is called before the first frame update

    public bool cultistCalled;
    public BookInteract book;
    public NewCamScript cams;
    public GameObject interactingUis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttemptCall(GameObject cultist)
	{
        if(book.BookOpen && !cultistCalled)
		{
            cultistCalled = true;
            book.bookOpenClose();

            // effects here n shitttt

            cams.LookCenter();
            cultist.transform.position = new Vector3(0, 0, 20);
            LeanTween.move(cultist, new Vector3(0,0,0), 2f).setEaseOutCubic();
            interactingUis.SetActive(true);

            // ok code continues


        }
	}
}
