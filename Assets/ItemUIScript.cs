using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUIScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool Item;
    public bool CreatureItem;
    public bool Blood;

    public string itemName;

    public GameObject item;

    public bool pickedUp;

    public ritual RitScript;

    public void OnBeginDrag(PointerEventData eventData)
	{
        print("true");
        pickedUp = true;
    }

	public void OnDrag(PointerEventData eventData)
	{
        transform.position = Input.mousePosition;
        this.GetComponent<Image>().raycastTarget = false;
    }

	public void OnEndDrag(PointerEventData eventData)
	{
        pickedUp = false;
        this.GetComponent<Image>().raycastTarget = true;

        if (RitScript.hoveredUI != null)
        {
            transform.position = RitScript.hoveredUI.transform.position;
        }
    }
}
