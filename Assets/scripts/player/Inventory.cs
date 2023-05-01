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
                Instantiate(resourceTemp, GameObject.Find("Inventory").transform).name = Item;
			}
		}

        foreach (string Item in CreatureItems)
        {
            int Amount = 3;
            PlrInv.Add(Item, Amount);

            for (int i = 0; i < PlrInv[Item]; i++)
            {
                Instantiate(resourceTemp, GameObject.Find("Inventory").transform).name = Item;
            }
        }

        print(PlrInv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
