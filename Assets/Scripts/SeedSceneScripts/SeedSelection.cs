using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    public GameObject seedPrefab;
    public static GameObject seed;
    static public bool seedSelect = false;

    public void ButtonClicked()
    {
        seed = Instantiate(seedPrefab);
        seed.tag = "Seed";
        Debug.Log("Seed doesnt exists!");
        seedSelect = true;
        DirtSelection.dirtSelect = false;
        WaterSelection.waterSelect = false;
        RepotSelection.repotSelect = false;
        DeadPlantSelection.deadPlantSelect = false;
        PlantSelection.plantSelect = false;
        WeedSelection.weedSelect = false;
    }
}
