using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Tray Item", menuName = "Seed Tray/Seed Tray Item")]
public class SeedTrayObject : ScriptableObject
{
    public List<SeedTraySlot> Container = new List<SeedTraySlot>();
    public GameObject drag_Dirt;
    public ItemObject dirt;
    public GameObject drag_Seed;
    public ItemObject seed;

    //needs to only add item with tag dirt and seed
    //if no dirt, then dirt can be placed. If dirt, then dirt cannot be placed and seed can be placed
    //drag objects will be destroyed once item is placed
    //Question is do I place that here or do an override function in a script on the object?


    public void AddItem(ItemObject _item, int _amount) 
    {
        bool hasItem = false;
        for(int i=0; i < Container.Count; i++) 
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new SeedTraySlot(_item, _amount));
        }
    }   
}

[System.Serializable]
public class SeedTraySlot 
{
    public ItemObject item;
    public int amount;
    public SeedTraySlot(ItemObject _item, int _amount) 
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value) 
    {
        amount += value;
    }
}
