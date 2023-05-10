using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> PlrInv = new Dictionary<string, int>();

    public List<string> ResourceItems = new List<string>() { "Gold", "Obsidian", "Salt", "Sapphire", "Bone"};
    public List<string> CreatureItems = new List<string>() { "Matches", "Herbs", "Salts", "Crucifix", "Magnesium" };
    // Start is called before the first frame update

    public int ItemBonus; // from menu

    public GameObject resourceTemp;

    public GameObject itemDefault;

    public GameObject RitualStuff;

    public GameBuilder gb;
    void Start()
    {
        //randomise inventory


        foreach(string Item in ResourceItems)
		{
            int Amount = 0;
            int randomVal = Random.Range(0, 10);
            if( randomVal < 2)
			{
                Amount = 2;
			} else if(randomVal >= 2 && randomVal < 8)
			{
                Amount = 3;
			} else if(randomVal >= 8)
			{
                Amount = 4;
			}

            Amount += ItemBonus - 1;

            PlrInv.Add(Item, Amount);

            for(int i = 0; i<PlrInv[Item]; i++)
			{
                GameObject item2 = Instantiate(itemDefault, RitualStuff.transform);
                item2.name = Item;
                item2.transform.position = new Vector2(Random.Range(0, Screen.width / 3.2f), Random.Range(0,Screen.height));
                item2.GetComponent<ItemUIScript>().Item = true;
            }
		}

        foreach (string Item in CreatureItems)
        {
            int Amount = 3;
            PlrInv.Add(Item, Amount);


            print(Item);

            GameObject item2 = Instantiate(itemDefault, RitualStuff.transform);
            item2.name = Item;
            item2.transform.position = new Vector2(Random.Range((Screen.width /4f) * 3, Screen.width), Random.Range(0, Screen.height));
            item2.GetComponent<ItemUIScript>().CreatureItem = true;
            item2.GetComponent<ItemUIScript>().itemName = Item;
        }

        // FIRE TO LOADING SCREEN TO SKIP/STOP LOADING

        RitualStuff.transform.parent.parent.gameObject.SetActive(false);

        //print(PlrInv);
    }

    public void newItem(string nam)
	{
        GameObject item2 = Instantiate(itemDefault, RitualStuff.transform);
        item2.name = nam;
        item2.transform.position = new Vector2(Random.Range((Screen.width / 4f) * 3, Screen.width), Random.Range(0, Screen.height));
        item2.GetComponent<ItemUIScript>().Blood = true;
        item2.GetComponent<ItemUIScript>().itemName = nam;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
