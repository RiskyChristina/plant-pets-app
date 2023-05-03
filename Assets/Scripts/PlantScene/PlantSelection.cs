using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSelection : MonoBehaviour
{
    static public bool plantSelect = false;
    public void ButtonSelected()
    {
        Debug.Log("Plant Selected");
        plantSelect = true;
        SeedSelection.seedSelect = false;
        DirtSelection.dirtSelect = false;
        RepotSelection.repotSelect = false;
        WaterSelection.waterSelect = false;
        DeadPlantSelection.deadPlantSelect = false;
        WeedSelection.weedSelect = false;
    }
}
