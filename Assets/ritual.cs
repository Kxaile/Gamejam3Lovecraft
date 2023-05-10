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

    public GameObject exrocismBook;
    public GameObject cleanseBook;

    public List<string> cleanseRecipe;
    public List<string> exorcismRecipe;


    void Start()
    {
        transfusionRecipes.Add("Gold", new List<string>() { "Obsidian", "Salt", "Sapphire" });
        transfusionRecipes.Add("Obsidian", new List<string>() { "Sapphire", "Bone", "Salt" });
        transfusionRecipes.Add("Sapphire", new List<string>() { "Gold", "Obsidian", "Bone" });
        transfusionRecipes.Add("Salt", new List<string>() { "Bone", "Sapphire", "Gold" });
        transfusionRecipes.Add("Bone", new List<string>() { "Salt", "Gold", "Obsidian" });

        randomiseCleanse();
    }

    public void createExorcistRecipe(string infected, string evil)
	{
        exorcismRecipe.Add(infected);

        print("EVIL IS -------------------------------------------");

        print(evil);

        switch (evil)
		{
            case "Shoggoth":
                exorcismRecipe.Add("Matches");
                break;
            case "NyarlathotepH":
                exorcismRecipe.Add("Magnesium");
                break;
            case "Kassogtha":
                exorcismRecipe.Add("Herbs");
                break;
            case "Golonac":
                exorcismRecipe.Add("Matches");
                break;
            case "Azathoth":
                exorcismRecipe.Add("Salts");
                break;

        }


        List<string> itemsss = new List<string>(inventory.ResourceItems);

        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, itemsss.Count);
            exorcismRecipe.Add(itemsss[index]);
            itemsss.RemoveAt(index);
        }

        // update book
    }
    public void randomiseCleanse()
	{
        List<string> itemsss = new List<string>(inventory.ResourceItems);

        for (int i = 0; i < 4; i++)
		{
            int index = Random.Range(0, itemsss.Count);
            cleanseRecipe.Add(itemsss[index]);
            itemsss.RemoveAt(index);
		}

        //update book
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

    public void ExorWin()
	{
        Application.Quit();
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

        if (compareRecipes(cleanseRecipe, recipe))
        {
            Destroy(item1.GetChild(0).gameObject);
            Destroy(item2.GetChild(0).gameObject);
            Destroy(item3.GetChild(0).gameObject);
            Destroy(item3.GetChild(4).gameObject);
            cleanse();
            success = true;
        }

        if (!success)
        {
            //PLAY BIG BUZZER OBNOXIOUS SOUND LIKE IN ALWAYS SUNNY EHHEHEHEHE
        }
    }

    public void damageItem(string item)
	{
        inventory.damage(item);
	}

    public void exorcismCraft()
	{
        Transform holder = Exorcise.transform.GetChild(0).GetChild(0);
        Transform Blood = holder.GetChild(1);
        Transform CreatureItem = holder.GetChild(2);
        Transform item1 = holder.GetChild(3);
        Transform item2 = holder.GetChild(4);
        Transform item3 = holder.GetChild(5);
        Transform item4 = holder.GetChild(6);
        List<string> recipe = new List<string>() { Blood.GetChild(0).gameObject.name, CreatureItem.GetChild(0).gameObject.name, item1.GetChild(0).gameObject.name, item2.GetChild(0).gameObject.name, item3.GetChild(0).gameObject.name, item4.GetChild(0).gameObject.name };

        if (CreatureItem.GetChild(0).GetComponent<ItemUIScript>().CreatureItem)
        {
            if(inventory.PlrInv[CreatureItem.GetChild(0).gameObject.name] > 0)
			{
                damageItem(CreatureItem.GetChild(0).gameObject.name);

                if(compareRecipes(exorcismRecipe, recipe)) 
                {
                    ExorWin();
			    }
			}
            //Destroy(Blood.GetChild(0));
		}
		else
		{
            Destroy(CreatureItem.GetChild(0));
		}

        Destroy(item1.GetChild(0));
        Destroy(item2.GetChild(0));
        Destroy(item3.GetChild(0));
        Destroy(item3.GetChild(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
