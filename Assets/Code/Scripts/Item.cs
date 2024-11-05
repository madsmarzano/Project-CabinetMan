using UnityEngine;

[System.Serializable]
public class Item
{
    //public int itemId;
    public string itemName;
    public string itemText;

    public Texture2D itemIcon;

    public bool isUsable;
    public bool isCD;

    public Item(string name, string text, bool usable, bool cd)
    {
        itemName = name;
        //itemId = id;
        itemText = text;
        isUsable = usable;
        isCD = cd;

        //itemIcon = Resources.Load("ItemIcons" + name);
    }

}
