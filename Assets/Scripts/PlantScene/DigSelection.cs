using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSelection : MonoBehaviour
{
    static public bool digSelect = false;
    public void ButtonClicked()
    {
        //repot = Instantiate(repotPrefab);
        //repot.tag = "Repot";
        Debug.Log("Repot Selected");
        digSelect = true;
        DirtSelection.dirtSelect = false;
        WaterSelection.waterSelect = false;
        SeedSelection.seedSelect = false;
        DeadPlantSelection.deadPlantSelect = false;
        RepotSelection.repotSelect = false;
    }
}
