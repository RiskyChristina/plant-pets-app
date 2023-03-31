using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    Dirt,
    Seed,
    Plant,
    Water,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab; //holds display for item
    public ItemType type; //store what type the item type is
}
