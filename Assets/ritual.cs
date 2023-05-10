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

    public GameObject defaultItem;

    public Dictionary<string, List<string>> transfusionRecipes = new Dictionary<string, List<string>>();

    void Start()
    {
        transfusionRecipes.Add("Gold", new List<string>() { "Obsidian", "Salt", "Sapphire" });
        transfusionRecipes.Add("Obsidian", new List<string>() { "Sapphire", "Bone", "Salt" });
        transfusionRecipes.Add("Sapphire", new List<string>() { "Gold", "Obsidian", "Bone" });
        transfusionRecipes.Add("Salt", new List<string>() { "Bone", "Sapphire", "Gold" });
        transfusionRecipes.Add("Bone", new List<string>() { "Salt", "Gold", "Obsidian" });
    }
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

    public void newItem(string item, Transform parent1)
	{
        GameObject item2 = Instantiate(defaultItem, parent1);
        item2.name = item;
        item2.transform.position = parent1.transform.position;
        item2.GetComponent<ItemUIScript>().Item = true;
        item2.transform.localScale = new Vector3(1, 1, 1);
    }

    public void cleanse()
	{
        //cleanse
	}

    public bool compareRecipes(List<string> recipe, List<string> items)
	{
        for (int i = 0; i < recipe.Count; i++)
        {
            if (recipe[i] != items[i])
            {
                return false;
            }
        }

        return true;
    }
    public void transmutationCraft()
	{
        Transform holder = Transmutate.transform.GetChild(0).GetChild(0);
        Transform item1 = holder.GetChild(1);
        Transform item2 = holder.GetChild(2);
        Transform item3 = holder.GetChild(3);
        Transform result = holder.GetChild(4);
        List<string> recipe = new List<string>() { item1.GetChild(0).gameObject.name, item2.GetChild(0).gameObject.name, item3.GetChild(0).gameObject.name };
        bool success = false;

        foreach(string item in recipe)
		{
            print(item);
		}

        foreach(KeyValuePair<string, List<string>> Craftrecipe in transfusionRecipes)
		{
            if(compareRecipes(Craftrecipe.Value, recipe))
			{
                Destroy(item1.GetChild(0).gameObject);
                Destroy(item2.GetChild(0).gameObject);
                Destroy(item3.GetChild(0).gameObject);
                newItem(Craftrecipe.Key, result);
                success = true;
            }
		}

		if (!success)
		{
            //PLAY BIG BUZZER OBNOXIOUS SOUND LIKE IN ALWAYS SUNNY EHHEHEHEHE
		}
    }

    public void blessCraft()
    {
        Transform holder = Cleanse.transform.GetChild(0).GetChild(0);
        Transform item1 = holder.GetChild(1);
        Transform item2 = holder.GetChild(2);
        Transform item3 = holder.GetChild(3);
        Transform item4 = holder.GetChild(4);
        List<string> recipe = new List<string>() { item1.GetChild(0).gameObject.name, item2.GetChild(0).gameObject.name, item3.GetChild(0).gameObject.name, item4.GetChild(0).gameObject.name };
        bool success = false;

        foreach (string item in recipe)
        {
            print(item);
        }

        foreach (KeyValuePair<string, List<string>> Craftrecipe in transfusionRecipes)
        {
            if (compareRecipes(Craftrecipe.Value, recipe))
            {
                Destroy(item1.GetChild(0).gameObject);
                Destroy(item2.GetChild(0).gameObject);
                Destroy(item3.GetChild(0).gameObject);
                Destroy(item3.GetChild(4).gameObject);
                cleanse();
                success = true;
            }
        }

        if (!success)
        {
            //PLAY BIG BUZZER OBNOXIOUS SOUND LIKE IN ALWAYS SUNNY EHHEHEHEHE
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
