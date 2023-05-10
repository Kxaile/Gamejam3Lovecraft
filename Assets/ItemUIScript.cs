using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemUIScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public bool Item;
    public bool CreatureItem;
    public bool Blood;

    public string itemName;

    public GameObject item;

    public GameObject holder;

    public bool pickedUp;

    public ritual RitScript;

    public GameObject nameItem;
    public Inventory inv;

	private void Start()
	{
        inv = GameObject.Find("RuntimeScripts").GetComponent<Inventory>();
        RitScript = GameObject.Find("Rituals").GetComponent<ritual>();
        holder = GameObject.Find("RitItems").transform.GetChild(0).GetChild(0).gameObject;
        nameItem = GameObject.Find("NameCanvas").transform.GetChild(0).gameObject;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
        print("true");
        pickedUp = true;
        transform.SetParent(holder.transform);
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
            transform.SetParent(RitScript.hoveredUI.transform);
        }
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (CreatureItem)
		{
            int amount = inv.PlrInv[itemName];
            nameItem.GetComponent<TMP_Text>().text = this.name + "(" + amount + ")";
        }
		else
		{
            nameItem.GetComponent<TMP_Text>().text = this.name;
		}

        
        //nameItem.SetActive(true);

	}

	public void OnPointerExit(PointerEventData eventData)
	{
        nameItem.GetComponent<TMP_Text>().text = "";
        //nameItem.SetActive(false);
    }
}
