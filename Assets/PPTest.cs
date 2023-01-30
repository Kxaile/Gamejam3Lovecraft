using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering; // HAVE TO USE THESE
using UnityEngine.Rendering.HighDefinition;

public class PPTest : MonoBehaviour
{
    // Start is called before the first frame update

    public Volume PP; // set this to cam volume or osmething idk man

    void Start()
    {
        PP.profile.TryGet<ChromaticAberration>(out var CA); // so youre gonna want to call .TryGet on the effect you want to edit, and then push it out to a variable of a name of your choosing

        CA.intensity.value = 0.15f; // edit the variable
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}