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
    public questioning questionModule;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dismiss(GameObject cultist)
	{
        cultistCalled = false;
        //book.bookOpenClose();

        // effects here n shitttt

        // maybe we make the stuff fly in idk man 

        cams.LookCenter();
        LeanTween.move(cultist, new Vector3(0, 0, 20), 2f).setEaseOutCubic();
        //cultist.transform.position = new Vector3(0, 20, 20);
        interactingUis.SetActive(false);

        // ok code continues

        questionModule.newRoundOfQuestioning(cultist);
    }

    public void AttemptCall(GameObject cultist)
	{
        if(book.BookOpen && !cultistCalled && cultist.GetComponent<TraitHandler>().Questions > 0)
		{
            cultistCalled = true;
            book.bookOpenClose();

            // effects here n shitttt

            // maybe we make the stuff fly in idk man 

            cams.LookCenter();
            cultist.transform.position = new Vector3(0, 0, 20);
            LeanTween.move(cultist, new Vector3(0,0,0), 2f).setEaseOutCubic();
            interactingUis.SetActive(true);

            // ok code continues

            questionModule.newRoundOfQuestioning(cultist);
        }
	}
}
