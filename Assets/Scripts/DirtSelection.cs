using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DirtSelection : MonoBehaviour
{
    public GameObject dirtPrefab;
    public static GameObject dirt;
    static public bool dirtSelect = false;

    public void ButtonClicked()
    {
            dirt = Instantiate(dirtPrefab);
            dirt.tag = "Dirt";
            Debug.Log("Dirt doesnt exists!");
            dirtSelect = true;
            SeedSelection.seedSelect = false;
    }
}
