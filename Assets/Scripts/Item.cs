using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject dirt;
    public GameObject seed;
    public GameObject container;
    public bool dirtFull;
    public bool seedFull;

    public void Start()
    {
        dirtFull = false;
        seedFull = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //check to see if hasDirt. If true check to see if hasSeed
        //if hasDirt is false, can place dirt but not seed
        //if hasDirt is true, cannot place dirt but place seed
        //if hasSeed is true, cannot place seed or dirt
        container = GameObject.FindWithTag("Container");
        dirt = GameObject.FindWithTag("Dirt");
        seed = GameObject.FindWithTag("Seed");

        if (dirt) 
        {
            dirtFull = true;
        }

        if (dirt && seed)
        {
            seedFull = true;
        }
        
    }
}
