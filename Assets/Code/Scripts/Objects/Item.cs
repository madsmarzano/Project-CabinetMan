using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemname;
    public Sprite itemIcon;
    public string useWith;
    public bool isUsable;
    public bool isCD;

    public Item(string itemname, Sprite itemIcon, string useWith, bool isUsable, bool isCD)
    {
        this.itemname = itemname;
        this.itemIcon = itemIcon;
        this.useWith = useWith;
        this.isUsable = isUsable;
        this.isCD = isCD;
    }
}
