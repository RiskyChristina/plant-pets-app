using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    //public GameObject seed_Drag;
    //public GameObject seed_Game;
    public Canvas canvas;
    private GameObject objectDragInstance;
    //private GameObject seedDragInstance;
    private GameManager gameManager;
    private ObjectContainer dirtContainer;

    public void Start()
    {
        gameManager = GameManager.instance;
        dirtContainer = ObjectContainer.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        objectDragInstance.transform.position = Input.mousePosition;
        //seedDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate(object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;
        objectDragInstance.GetComponent<ObjectDragging>().card = this;

        GameManager.instance.draggingObject = objectDragInstance;

        //seedDragInstance = Instantiate(seed_Drag, canvas.transform);
        //seedDragInstance.transform.position = Input.mousePosition;
        //seedDragInstance.GetComponent<ObjectDragging>().card = this;

        //GameManager.instance.draggingSeed = seedDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dirtContainer.GetComponent<ObjectContainer>().isDirtFull == false && dirtContainer.GetComponent<ObjectContainer>().isSeedFull == false)
        {
            gameManager.PlaceObject();
            GameManager.instance.draggingObject = null;
            Destroy(objectDragInstance);
        } 
        
        //if (dirtContainer.GetComponent<ObjectContainer>().isDirtFull == true && dirtContainer.GetComponent<ObjectContainer>().isSeedFull == false) 
          //{
            //gameManager.PlaceSeed();
            //GameManager.instance.draggingSeed = null;
            //Destroy(seedDragInstance);
          //}
    }
}
