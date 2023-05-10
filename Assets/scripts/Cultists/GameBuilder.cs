using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    public gameStartOptions buildData;

    public int NumCultists;
    public int NumEvil;
    public GameObject cultistParent;
    public string chosenEvil;

    public ritual rits;
    public BookInteract book;
    public Inventory inv;

    public int ChanceForSecondPositive;
    public int ChanceForNegative;

    public List<string> Names = new List<string> { "Jebediah", "Chris", "Craig", "Damian", "Viktor", "Gus", "Hector", "Mac", "Dennis", "Charlie", "Frank", "Kyle", "Harri", "Lawrence", "Rohan", "Miri", "Stan", "Eric",  "Kenny", "Alex", "Jack", "Deandra", "Artemis", "Amanda", "Victoria", "Mabel", "Violet", "Helena", "Beatrice", "Ebba", "Alexandra", "Josie" };
    public List<string> Evils = new List<string> { "Shoggoth", "Kassogtha", "Azathoth", "Golonac", "Nyarlathoteph"};
    public List<string> Rooms = new List<string> { "Kitchen", "Attic", "Hallway", "Bedrooms", "Office", "Library", "Observatory" };

    public List<GameObject> Cultists;

    private Dictionary<string, System.Type> evilBehaviours = new Dictionary<string, System.Type>
    {
        {"Shoggoth", typeof(B_Shoggoth)},
        {"Kassogtha", typeof(B_Kassogtha)},
        {"Azathoth", typeof(B_Azathoth)},
        {"Golonac", typeof(B_Golonac)},
        {"Nyarlathotep", typeof(B_Nyarlathoteph)},
    };



    /*public class cultist
	{
        public string name;
        public int age;
        public bool evil;
        public gameobject gonpc;

        public cultist(string na, int ag, bool es, gameobject ga)
        {
            name = na;
            age = ag;
            evil = es;
            gonpc = ga;
                                                                
        }

        public cultist()
		{
            name = "john doe";
            age = 69;
            evil = false;
            gonpc = instantiate(resources.load("cultistdefault")) as gameobject;
        }
	}*/                                                                                                 // so this is literally useless :| kinda annoying but theres just a better way to do it lmao

    void Start()
    {
        buildData = this.GetComponent<gameStartOptions>();
        NumCultists = buildData.numOfCultists;
        chosenEvil = Evils[Random.Range(0, Evils.Count)];


        for (int i = 0; i < NumCultists; i++)
		{
            GameObject culty = Instantiate(Resources.Load("CultistDefault")) as GameObject;
            culty.transform.parent = cultistParent.transform;
            // TRAITS AND BEHAVIOUR SCRIPTS // 

            B_Normal currScript = culty.AddComponent<B_Normal>(); // ADD BASE SCRIPT
            TraitHandler TraitScript = culty.AddComponent<TraitHandler>();  // ADDING THE TRAIT HANDLER

            int Age = Random.Range(16, 50);

            currScript.Age = Age;

            print(TraitScript);

            // PICKING NAME // 

            int x = Random.Range(0, Names.Count);
            inv.newItem(Names[x]);
            culty.gameObject.name = Names[x];
            Names.RemoveAt(x);

            TraitScript.Faith = Random.Range(0, 11);
            TraitScript.Mentality = Random.Range(0, 11);
            TraitScript.Perception = Random.Range(0, 11);

            if (i >= NumCultists - NumEvil) // ADDING STARTING EVIL SCRIPT
			{
                culty.AddComponent(evilBehaviours[chosenEvil]);

                rits.createExorcistRecipe(culty.gameObject.name, chosenEvil);
			}

            Cultists.Add(culty);

            culty.transform.localPosition = new Vector3(-(NumCultists*2) + i * 5, 0, 0);
		}

        book.buildPages();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
