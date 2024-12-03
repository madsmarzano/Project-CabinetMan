using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable
{
    public enum ladderType
    {
        DOWN,
        UP
    };

    public GameObject[] floorSpawnPoint;

    public ladderType ladderDirection;

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;

        if (!GameManager.instance.visitedSecondFloor)
        {
            TextDisplay.Instance.ChangeTextDisplay("I should try climbing this ladder and see where it goes...");

            TravelToFloor((int)ladderDirection);
        }
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
    }

    public void TravelToFloor(int floor)
    {
        player.transform.position = floorSpawnPoint[floor].transform.position;
    }

    public override void UniqueStart()
    {
        base.UniqueStart();
    }

    public override void UniqueUpdate()
    {
        base.UniqueUpdate();
    }
}
