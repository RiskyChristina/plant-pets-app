using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*public class Drag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Canvas canvas;
    private DirtSelection dirtSelection;

    public void Start()
    {
        dirtSelection = GetComponent<DirtSelection>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        dirtDrag = DirtSelection.Dirt;
        dirtDrag.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dirtDrag = Instantiate(dirtDrag, canvas.transform);
        dirtDrag.transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}*/

public class Drag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Canvas canvas;
    private DirtSelection dirtSelection;
    private Item item;
    private GameObject itemDrag;

    public void Start()
    {
        dirtSelection = GetComponent<DirtSelection>();
        item = GetComponent<Item>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemDrag != null) // check if itemDrag is initialized before using it
        {
            itemDrag.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!item.dirtFull || !item.seedFull) // check if dirt or seed can be placed
        {
            itemDrag = Instantiate(dirtSelection.dirtPrefab, canvas.transform);
            itemDrag.transform.position = Input.mousePosition;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (itemDrag != null)
        {
            if (!item.dirtFull || !item.seedFull) // check if dirt or seed can be placed
            {
                if (itemDrag.tag == "Dirt")
                {
                    item.dirtFull = true;
                }
                else if (itemDrag.tag == "Seed")
                {
                    item.seedFull = true;
                }
            }
            else
            {
                Destroy(itemDrag); // if both dirt and seed are full, destroy the item
            }
        }
    }
}


