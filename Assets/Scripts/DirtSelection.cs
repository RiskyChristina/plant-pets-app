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
        if (dirt == null) // only create a new dirt object if one doesn't exist already
        {
            dirt = Instantiate(dirtPrefab);
            dirt.tag = "Dirt";
            Debug.Log("Dirt doesnt exists!");
            dirtSelect = true;
        }
        else
        {
            Debug.Log("Dirt already exists!");
        }
    }
}
