using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : Interactable
{
    GameObject musicCD;
    public override void UniqueStart()
    {
        base.UniqueStart();
        musicCD = GameObject.Find("CD3");
        musicCD.SetActive(false);
        if (GameManager.instance.posterChecked == true)
        {
            gameObject.SetActive(false);
        }
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("Hey, there's a CD behind this poster!");
        gameObject.SetActive(false);
        musicCD.SetActive(true);
        GameManager.instance.posterChecked = true;
    }


    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("I don't think I can do anything with this.");
    }


    // Start is called before the first frame update
}
