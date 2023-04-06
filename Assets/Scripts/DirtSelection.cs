using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class DirtSelection : MonoBehaviour
{
    public static GameObject Dirt;
    //public static DirtSelection instance;

    public void ButtonClicked() 
    {
        Dirt = GameObject.FindWithTag("DirtDrag");
        Debug.Log("Dirt Selected");
    }
}*/

public class DirtSelection : MonoBehaviour
{
    public GameObject dirtPrefab;
    public static GameObject dirt;

    public void ButtonClicked()
    {
        if (dirt == null) // only create a new dirt object if one doesn't exist already
        {
            dirt = Instantiate(dirtPrefab);
            dirt.tag = "Dirt";
        }
        else
        {
            Debug.Log("Dirt already exists!");
        }
    }
}
