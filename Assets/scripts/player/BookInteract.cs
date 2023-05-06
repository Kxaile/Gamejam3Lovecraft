using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BookInteract : MonoBehaviour
{
    // Start is called before the first frame update
    public NewCamScript cameraScript;
    public GameObject book;
    public GameObject cultistHolder;
    public GameObject pageBase;


    public Transform bookStartPos;
    public Transform bookOpenPos;

    public bool BookOpen;
    public int CurrentPage = 0;
    public int MaxPages = 0;
    void Start()
    {
        BookOpen = false;
        pageBase = Resources.Load("CultistBaseLayout") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && cameraScript.LookingDown)
		{
            bookOpenClose();
		}

		if (BookOpen)
		{
			if (Input.GetKeyDown("a") && CurrentPage != 0)
			{
                CurrentPage -= 1;
                UpdatePages();
                AkSoundEngine.PostEvent("Stop_Pages_sounds", this.gameObject);
                AkSoundEngine.PostEvent("Play_Pages_sounds", this.gameObject);
			}

            if (Input.GetKeyDown("d") && CurrentPage != MaxPages)
            {
                CurrentPage += 1;
                UpdatePages();
                AkSoundEngine.PostEvent("Stop_Pages_sounds", this.gameObject);
                AkSoundEngine.PostEvent("Play_Pages_sounds", this.gameObject);

            }
        }
    }

    public void bookOpenClose()
	{
            if (!BookOpen)
			{
                LeanTween.move(this.gameObject, bookOpenPos.transform, 0.6f).setEaseOutCubic();
                LeanTween.rotate(this.gameObject, bookOpenPos.eulerAngles, 0.6f).setEaseOutCubic();
                BookOpen = true;
            } else
			{
                LeanTween.move(this.gameObject, bookStartPos.transform, 0.6f).setEaseOutCubic();
                LeanTween.rotate(this.gameObject, bookStartPos.eulerAngles, 0.6f).setEaseOutCubic();
                BookOpen = false;
            }
	}

    public void UpdatePages()
	{
        foreach (Transform pageT in book.transform.Find("LeftPage"))
        {
            GameObject page = pageT.gameObject;
            int pageNum = page.GetComponent<pageScript>().number;

            if(pageNum == CurrentPage)
			{
                page.SetActive(true);
			}
			else
			{
                page.SetActive(false);
            }
        }

        foreach (Transform pageT in book.transform.Find("RightPage"))
        {
            GameObject page = pageT.gameObject;
            int pageNum = page.GetComponent<pageScript>().number;

            if (pageNum == CurrentPage)
            {
                page.SetActive(true);
            }
            else
            {
                page.SetActive(false);
            }
        }
    }

    public void buildPages()
	{
        int pageSet = 1;
        bool left = true;
        int numPlaced = 0;

        foreach (Transform cultistT in cultistHolder.transform)
		{
            GameObject cultist = cultistT.gameObject;

            TraitHandler traits = cultist.GetComponent<TraitHandler>();
            B_Normal cultistStats = cultist.GetComponent<B_Normal>();

            print(cultistStats);
            print(cultistStats.Age);

            GameObject page = Instantiate(pageBase);

            traits.diaryPage = page;

            page.transform.Find("Name").GetComponent<TMPro.TextMeshProUGUI>().text = cultist.name;
            page.transform.Find("Age").GetComponent<TMPro.TextMeshProUGUI>().text = "Age: " + cultist.GetComponent<B_Normal>().Age.ToString();

            string bioString = "Faith: " + traits.Faith.ToString() + "\nPerception: " + traits.Perception.ToString() + "\nMentality: " + traits.Mentality.ToString();

            page.transform.Find("Personality").GetComponent<TMPro.TextMeshProUGUI>().text = bioString;

            page.transform.Find("Button").GetComponent<CallScript>().cultist = cultist;

			if (left)
			{
                page.transform.SetParent(book.transform.Find("LeftPage"));
			} else
			{
                page.transform.SetParent(book.transform.Find("RightPage"));
            }

            page.transform.localPosition = new Vector3(0, 0, 0);
            page.transform.localEulerAngles = new Vector3(0, 0, 0);
            page.transform.localScale = new Vector3(1, 1, 1);

            page.GetComponent<pageScript>().number = pageSet;

			if (!left)
			{
                pageSet += 1;
                numPlaced = 0;
			}

            left = !left;
            numPlaced += 1;
        }

        MaxPages = pageSet;
        MaxPages -= 1;
        if (numPlaced == 0)
		{
            MaxPages -= 1;
		}

        UpdatePages();
	}

}
