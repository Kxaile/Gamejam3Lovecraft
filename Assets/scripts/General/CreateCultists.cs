using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCultists : MonoBehaviour
{
    public int NumCultists;
    public GameObject cultistParent;

    public List<string> MascNames = new List<string> { "Jebediah", "Chris", "Craig", "Damian", "Viktor", "Gus", "Hector", "Mac", "Dennis", "Charlie", "Frank" };
    public List<string> FemNames = new List<string> { "Deandra", "Artemis", "Amanda", "Victoria", "Mabel", "Violet", "Helena", "Beatrice", "Ebba", "Alexandra" };


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
        for (int i = 0; i < NumCultists; i++)
		{
            GameObject culty = Instantiate(Resources.Load("CultistDefault")) as GameObject;
            culty.transform.parent = cultistParent.transform;

            if (Random.Range(1,3) == 1)
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
            culty.transform.position = new Vector3(-(NumCultists*2) + i * 5, 0, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
