using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public string description;
    public Texture2D itemIcon;
    public bool itemUsable;
    public int itemUseWithID;


    public Item(string name, int id, string desc, bool usable, int useWithId)
    {
        itemName = name;
        itemID = id;
        description = desc;
        itemIcon = Resources.Load<Texture2D>("SampleSprites" + name);
        itemUsable = usable;
        itemUseWithID = useWithId;
    }
}
