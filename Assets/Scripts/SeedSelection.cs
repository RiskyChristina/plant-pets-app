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
        //if (seed == null) // only create a new dirt object if one doesn't exist already
        //{
            seed = Instantiate(seedPrefab);
            seed.tag = "Seed";
            Debug.Log("Seed doesnt exists!");
            seedSelect = true;
            DirtSelection.dirtSelect = false;
        /*}
        else
        {
            Debug.Log("Seed already exists!");
        }*/
    }
}
