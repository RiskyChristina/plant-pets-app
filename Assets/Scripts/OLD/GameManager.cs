using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public GameObject draggingSeed;
    public GameObject seedContainer;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void PlaceObject() 
    {
        if (draggingObject != null && currentContainer != null) 
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isDirtFull = true;
        }
    }

    public void PlaceSeed() 
    {
        if (draggingSeed != null && /*currentContainer != null &&*/ seedContainer != null /*&& currentContainer.GetComponent<ObjectContainer>().isDirtFull == true && currentContainer.GetComponent<ObjectContainer>().isSeedFull == false*/)
        {
            Instantiate(draggingSeed.GetComponent<SeedDragging>().scard.seed_Game, seedContainer.transform);
            seedContainer.GetComponent<ObjectContainer>().isSeedFull = true;
        }
    }
}
