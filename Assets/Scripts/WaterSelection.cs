using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSelection : MonoBehaviour
{
    public GameObject waterPrefab;
    public static GameObject water;
    static public bool waterSelect = false;

    public void ButtonClicked()
    {
        water = Instantiate(waterPrefab);
        water.tag = "Water";
        Debug.Log("Dirt doesnt exists!");
        waterSelect = true;
        SeedSelection.seedSelect = false;
        DirtSelection.dirtSelect = false;
    }
}
