using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public NewCamScript cameraScript;
    public GameObject book;

    public Transform bookStartPos;
    public Transform bookOpenPos;

    public bool BookOpen;
    void Start()
    {
        BookOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && cameraScript.LookingDown)
		{
			if (!BookOpen)
			{
                LeanTween.move(this.gameObject, bookOpenPos.transform, 0.1f).setEaseOutCubic();
                LeanTween.rotate(this.gameObject, bookOpenPos.eulerAngles, 0.1f).setEaseOutCubic();
                BookOpen = true;
            } else
			{
                LeanTween.move(this.gameObject, bookStartPos.transform, 0.1f).setEaseOutCubic();
                LeanTween.rotate(this.gameObject, bookStartPos.eulerAngles, 0.1f).setEaseOutCubic();
                BookOpen = false;
            }
		}
    }
}
