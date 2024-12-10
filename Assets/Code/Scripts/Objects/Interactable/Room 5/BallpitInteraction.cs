using UnityEngine;

/// <summary>
/// By Mads:
/// Handles interaction with the ball pit.
/// Determines appearance of the ball pit based on the amount of balls added.
/// </summary>

public class BallpitInteraction : Interactable
{
    GameObject balls;
    GameObject[] ballLayers = new GameObject[5];
    public GameObject staticBalls;

    public override void UniqueStart()
    {
        balls = transform.GetChild(0).gameObject;

        //Assign the children of the top layer balls gameobject to their respective layers
        for (int i = 0; i < ballLayers.Length; i++)
        {
            ballLayers[i] = balls.transform.GetChild(i).gameObject;
        }

        InitializeBallpit();
    }

    public override void OnCheck()
    {
        base.OnCheck();
        GameManager.instance.interactionInProgress = true;
        TextDisplay.Instance.ChangeTextDisplay("The ball pit is " + GameManager.instance.ballpitPercentFull + "% full.");
    }

    public override void OnItemUsed()
    {
        base.OnItemUsed();
        GameManager.instance.interactionInProgress = true;
        //check for ballpit balls in inventory
        foreach (Item item in GameManager.instance.Inventory)
        {
            if (item.useWith == gameObject.name)
            {
                GameManager.instance.ballpitPercentFull += 10;
                UpdateBallPit();
                TextDisplay.Instance.ChangeTextDisplay("I've added some balls to the ball pit.");

                //Remove item from inventory
                GameManager.instance.Inventory.Remove(item);
                GameManager.instance.inventoryUpdated = false;
                return;
            }
        }
        //Entire inventory was searched and no item was found.
        TextDisplay.Instance.ChangeTextDisplay("I don't have anything in my inventory to use with this.");
    }

    public void UpdateBallPit()
    {
        if (GameManager.instance.ballpitPercentFull > 50 && !staticBalls.activeSelf)
        {
            staticBalls.SetActive(true);
        }
        switch (GameManager.instance.ballpitPercentFull)
        {
            case 0: break;
            case 10:
                ballLayers[0].SetActive(true); break;
            case 20:
                ballLayers[1].SetActive(true); break;
            case 30:
                ballLayers[2].SetActive(true); break;
            case 40:
                ballLayers[3].SetActive(true); break;
            case 50:
                ballLayers[4].SetActive(true); break;
            //Past 50%, raise the level of the ballpit balls to simulate the ballpit filling up.
            case 60:
                balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z); break;
            case 70:
                balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.50f, transform.position.z); break;
            case 80:
                balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z); break;
            case 90:
                balls.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); break;
            case 100:
                balls.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z);
                //Additional logic indicating that the ballpit puzzle has been solved.
                GameManager.instance.ballpitFull = true;
                TextDisplay.Instance.ChangeTextDisplay("The ball pit is full! I should check in with that little guy...");
                interactionEnabled = false; //You can no longer interact with the ballpit
                break;

        }
    }

    public void InitializeBallpit()
    {
        if (GameManager.instance.ballpitPercentFull > 50)
        {
            staticBalls.SetActive(true);
        }

        for (int i = 0; i < GameManager.instance.ballpitPercentFull/10; i++)
        {
            if (i < 5)
            {
                //Determine how many balls are showing
                ballLayers[i].SetActive(true);
            }
            else if (i < 10)
            {
                //Determine height of the balls
                switch (i)
                {
                    case 5:
                        balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z); break;
                    case 6:
                        balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.50f, transform.position.z); break;
                    case 7:
                        balls.transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z); break;
                    case 8:
                        balls.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); break;
                    case 9:
                        balls.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z); break;
                }
            }
        }
    }
}
