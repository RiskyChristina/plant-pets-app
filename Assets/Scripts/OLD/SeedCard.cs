using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeedCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject seed_Drag;
    public GameObject seed_Game;
    public Canvas canvas;
    private GameObject seedDragInstance;
    private GameManager gameManager;
    private ObjectContainer dirtContainer;

    public void Start()
    {
        gameManager = GameManager.instance;
        dirtContainer = ObjectContainer.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        seedDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        seedDragInstance = Instantiate(seed_Drag, canvas.transform);
        seedDragInstance.transform.position = Input.mousePosition;
        seedDragInstance.GetComponent<SeedDragging>().scard = this;

        GameManager.instance.draggingSeed = seedDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (dirtContainer.GetComponent<ObjectContainer>().isDirtFull == true && dirtContainer.GetComponent<ObjectContainer>().isSeedFull == false)
        {
            gameManager.PlaceSeed();
            GameManager.instance.draggingSeed = null;
            Destroy(seedDragInstance);
        }
    }
}