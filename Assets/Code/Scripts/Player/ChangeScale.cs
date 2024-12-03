using System.Collections;
using UnityEngine;

/// <summary>
/// Attached to the Player GameObject.
/// </summary>

public class ChangeScale : MonoBehaviour
{
    private Player player;

    public Vector3 humanSize = Vector3.one;
    public Vector3 bugSize = new Vector3(0.25f, 0.25f, 0.25f);

    [Tooltip("The amount of time in seconds it takes to complete the process of changing from one size to the other.")]
    public float scalingTimeSeconds = 2.0f;
    [Tooltip("Timer variable used in the update method to control the duration of the scale-change process.")]
    public float changeTimer = 0.0f;
    [Tooltip("Amount the scale and position will be changed each frame.")]
    private float changeIncrement;

    private bool sizeWarningDisplayed = false;

    public enum Size
    {
        HUMAN = 1,
        BUG = 2,
    }

    public Size currentSize;
    public Size startingSize = Size.HUMAN;
    public bool isChanging = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), 1f);
    }

    private void Awake()
    {
        player = GetComponent<Player>();

        changeIncrement = (humanSize.x - bugSize.x) / scalingTimeSeconds; //only using the x value of the Vector3's since I need a single float and the values are the same
    }

    private void Start()
    {
        if (player.isInVent)
        {
            SetStartingSize(2);
        }
        else
        {
            SetStartingSize(1);
        }

        //SetStartingSize((int)startingSize);
    }

    private void Update()
    {
        //References the input manager to determine if the input which changes the player's size has been activated.
        if (InputManager.SizeChangeTriggered() && player.canChangeSize && !isChanging)
        {
            //StartChange();
            if (currentSize == Size.BUG)
            {
                //If the Player is currently Bug-Size, check if the Player has room to grow.
                //If no objects are near the Player, size change will be triggered.
                bool canGrow = CheckRoomToGrow();
                if (canGrow)
                {
                    StartChange();
                }
                else
                {
                    Debug.Log("CANNOT GROW: Something is in the way!");
                    if (!sizeWarningDisplayed)
                    {
                        StartCoroutine(DisplaySizeWarning());
                    }
                    return;
                }
            }
            else if (currentSize == Size.HUMAN)
            {
                StartChange();
            }
        }

        if (changeTimer > 0.0f)
        {
            transform.localScale += new Vector3(changeIncrement, changeIncrement, changeIncrement) * Time.deltaTime;
            transform.position += new Vector3(0, changeIncrement, 0) * Time.deltaTime;
            changeTimer -= Time.deltaTime;
        }
        else
        {
            changeTimer = 0.0f;
        }

        if (changeTimer <= 0 && isChanging)
        {
            if (currentSize == Size.BUG)
            {
                transform.localScale = bugSize;
            }
            else if (currentSize == Size.HUMAN)
            {
                transform.localScale = humanSize;
            }
            isChanging = false;
        }
    }

    public void StartChange()
    {
        isChanging = true;

        changeTimer = scalingTimeSeconds;
        changeIncrement = -changeIncrement;

        if (currentSize == Size.HUMAN)
        {
            currentSize = Size.BUG;
            player.SetPlayerDataForSize((int)currentSize);
        }
        else
        {
            currentSize = Size.HUMAN;
            player.SetPlayerDataForSize((int)currentSize);
        }
    }

    public void SetStartingSize(int s)
    {
        //Takes the enum index as a parameter: 1 -- Human, 2 -- Bug
        if (s == 1)
        {
            transform.localScale = humanSize;
            currentSize = Size.HUMAN;
            player.SetPlayerDataForSize(s);
        }
        else
        {
            changeIncrement = -changeIncrement;
            transform.localScale = bugSize;
            currentSize = Size.BUG;
            player.SetPlayerDataForSize(s);
        }
    }

    /// <summary>
    /// By Mads:
    /// Creates a sphere around the Player, similar to the size that the Player is when human.
    /// </summary>
    /// <returns>The opposite of the raycast; FALSE if objects are detected, TRUE if objects are not detected.</returns>
    private bool CheckRoomToGrow()
    {
        //Sphere is slightly above Player so CheckSphere does not detect ground
        return (!Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y + 1.05f, transform.position.z), 1f));
    }

    public IEnumerator DisplaySizeWarning()
    {
        sizeWarningDisplayed = true;
        UIController.sizeChangeWarning.SetActive(true);
        yield return new WaitForSeconds(3);
        UIController.sizeChangeWarning.SetActive(false);
        sizeWarningDisplayed = false;
    }

}