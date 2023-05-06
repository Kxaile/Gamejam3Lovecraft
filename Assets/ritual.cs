using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ritual : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ritualHolder;

    public List<GameObject> Cultists;

    public bool ritualsOpen = false;

    public GameBuilder gameB;
    public Inventory inventory;
    public BookInteract bok;

    public GameObject hoveredUI;

    public GameObject Exorcise;
    public GameObject Cleanse;
    public GameObject Transmutate;

    public GameObject Items;

    public void openRituals()
	{
        ritualHolder.SetActive(!ritualsOpen);
        ritualsOpen = !ritualsOpen;
	}

    public void Exorcism()
	{
        Cultists = gameB.Cultists;
	}

    public void hoverUI(GameObject UIimg)
	{
        hoveredUI = UIimg;
	}

    public void leaveHover()
	{
        hoveredUI = null;
	}

    public void openExorcism()
	{
        bok.bookOpenClose();
        ritualsOpen = true;
        Exorcise.SetActive(true);
        Items.SetActive(true);
	}

    public void openCleanse()
    {
        bok.bookOpenClose();
        ritualsOpen = true;
        Cleanse.SetActive(true);
        Items.SetActive(true);
    }
    public void openTransumtation()
    {
        bok.bookOpenClose();
        ritualsOpen = true;
        Transmutate.SetActive(true);
        Items.SetActive(true);
    }

    public void leave()
	{
        ritualsOpen = false;
        Items.SetActive(false);
        Transmutate.SetActive(false);
        Cleanse.SetActive(false);
        Exorcise.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
