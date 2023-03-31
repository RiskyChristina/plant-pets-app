using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant Object", menuName = "Container System/Items/Plant")]
public class PlantObject : ItemObject
{
    public int plantHealthValue;
    //public int or float for when it needs water
    //public int or float for time it take to grow
    //public int or float when it hits max growth
    //public int or float for time it takes for health to decrease over time when not watered
    //Switch prefab image here?
    public void Awake()
    {
        type = ItemType.Plant;
    }
}
