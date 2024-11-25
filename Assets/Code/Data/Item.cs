using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemname;
    public Sprite itemIcon;
    public string useWith;
    public bool isCD;

    public Item(string itemname, Sprite itemIcon, string useWith, bool isCD)
    {
        this.itemname = itemname;
        this.itemIcon = itemIcon;
        this.useWith = useWith;
        this.isCD = isCD;
    }
}
