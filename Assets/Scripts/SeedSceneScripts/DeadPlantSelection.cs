using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlantSelection : MonoBehaviour
{
    //public GameObject shovelPrefab;
    //public static GameObject shovel;
    static public bool deadPlantSelect = false;

    public void ButtonClicked()
    {
        //shovel = Instantiate(shovelPrefab);
        //shovel.tag = "Shovel";
        Debug.Log("Dead Plant doesnt exists!");
        deadPlantSelect = true;
        SeedSelection.seedSelect = false;
        DirtSelection.dirtSelect = false;
        RepotSelection.repotSelect = false;
        WaterSelection.waterSelect = false;
        PlantSelection.plantSelect = false;
        WeedSelection.weedSelect = false;
    }
}
