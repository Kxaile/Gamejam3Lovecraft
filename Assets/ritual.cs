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

    public GameObject hoveredUI;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
