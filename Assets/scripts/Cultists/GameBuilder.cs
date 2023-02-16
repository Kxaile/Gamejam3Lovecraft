using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    public int NumCultists;
    public int NumEvil;
    public GameObject cultistParent;
    public string chosenEvil;

    public List<string> MascNames = new List<string> { "Jebediah", "Chris", "Craig", "Damian", "Viktor", "Gus", "Hector", "Mac", "Dennis", "Charlie", "Frank" };
    public List<string> FemNames = new List<string> { "Deandra", "Artemis", "Amanda", "Victoria", "Mabel", "Violet", "Helena", "Beatrice", "Ebba", "Alexandra" };
    public List<string> Evils = new List<string> { "Shoggoth", "Kassogtha", "Azathoth", "Golonac", "Nyarlathotep"};
    public List<string> Rooms = new List<string> { "Kitchen", "Attic", "Hallway", "Bedrooms", "Office", "Library", "Observatory" };

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
        chosenEvil = Evils[Random.Range(0, Evils.Count)];


        for (int i = 0; i < NumCultists; i++)
		{
            GameObject culty = Instantiate(Resources.Load("CultistDefault")) as GameObject;
            culty.transform.parent = cultistParent.transform;

            if (Random.Range(0,2) == 1)
			{
                int x = Random.Range(0, MascNames.Count);
                culty.gameObject.name = MascNames[x];
                MascNames.RemoveAt(x);

            } else
			{
                int x = Random.Range(0, FemNames.Count);
                culty.gameObject.name = FemNames[x];
                FemNames.RemoveAt(x);

                //change icon to fem one
            }

            culty.AddComponent<B_Normal>();

            if (i >= NumCultists - NumEvil)
			{
                culty.AddComponent(evilBehaviours[chosenEvil]);
			}
                

            culty.transform.position = new Vector3(-(NumCultists*2) + i * 5, Random.Range(3, 8), 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
