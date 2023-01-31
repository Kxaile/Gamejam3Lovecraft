using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCultists : MonoBehaviour
{
    public int NumCultists;
    public GameObject cultistParent;




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

            culty.transform.position = new Vector3(-(NumCultists*2) + i * 5, 0, 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
