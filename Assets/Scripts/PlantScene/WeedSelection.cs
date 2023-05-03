using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSelection : MonoBehaviour
{
    static public bool weedSelect = false;

    public void ButtonClicked()
    {
        weedSelect = true;
        SeedSelection.seedSelect = false;
        DirtSelection.dirtSelect = false;
        RepotSelection.repotSelect = false;
        DeadPlantSelection.deadPlantSelect = false;
        PlantSelection.plantSelect = false;
        WaterSelection.waterSelect = false;
    }
}
