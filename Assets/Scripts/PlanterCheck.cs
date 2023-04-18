using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterCheck : MonoBehaviour
{
    public GameObject placePlant1;
    public GameObject placePlant1Prefab;
    public GameObject happyEmote;
    public GameObject happyEmotePrefab;
    public GameObject deadEmote;
    public GameObject deadEmotePrefab;

    private int plant = 0;
    //private ContainerCheck containerCheck; Uncomment

    public void ButtonSelected() 
    {
        //containerCheck = GameObject.FindObjectOfType<ContainerCheck>(); Uncomment
        //int countPlantValue = containerCheck.countPlant; Uncomment

        if (PlantSelection.plantSelect && plant == 0) 
        {
            //countPlantValue--; //Uncomment when UI fixed for SeedScene
            placePlant1 = Instantiate(placePlant1Prefab, this.transform);
            happyEmote = Instantiate(happyEmotePrefab, this.transform);
            plant = 1;
            //Debug.Log("Number of plants planted: " + countPlantValue);
        }
    }


    /*public void PlacePlant(int subPlant)
    {
        containerCheck = GetComponent<ContainerCheck>();

        //for (int i = 0; i < containerCheckScript.countPlant[i].Length; i++) 
        //{
        //    containerCheckScript.countPlant[i] -= subPlant;
        //}
    }*/
}
