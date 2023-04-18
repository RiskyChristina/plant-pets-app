using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RepotSelection : MonoBehaviour
{
    //public GameObject repotPrefab;
    //public static GameObject repot;
    static public bool repotSelect = false;


    public void ButtonClicked()
    {
        //repot = Instantiate(repotPrefab);
        //repot.tag = "Repot";
        Debug.Log("Repot Selected");
        repotSelect = true;
        DirtSelection.dirtSelect = false;
        WaterSelection.waterSelect = false;
        SeedSelection.seedSelect = false;
        DeadPlantSelection.deadPlantSelect = false;
    }
}
