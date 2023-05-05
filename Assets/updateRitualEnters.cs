using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class updateRitualEnters : MonoBehaviour
{
    // Start is called before the first frame update
    public ritual ritScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered the UI element!");
        ritScript.hoveredUI = this.gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited the UI element!");
        ritScript.hoveredUI = null;
    }
}
