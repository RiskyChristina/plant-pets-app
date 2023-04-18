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

    public ContainerCheck containerCheckScript;

    public void ButtonSelected() 
    {
        if (PlantSelection.plantSelect && plant == 0) 
        {
            //ContainerCheck.harvestedPlant--;
            placePlant1 = Instantiate(placePlant1Prefab, this.transform);
            plant = 1;
            //Debug.Log("Number of plants harvested: " + instances.Length);
        }
    }


    public void PlacePlant(int subPlant)
    {
        containerCheckScript = GetComponent<ContainerCheck>();

        //for (int i = 0; i < containerCheckScript.countPlant[i].Length; i++) 
        //{
        //    containerCheckScript.countPlant[i] -= subPlant;
        //}
    }
}
