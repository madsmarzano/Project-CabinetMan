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

    public enum size
    {
        HUMAN = 1,
        BUG = 2,
    }

    public size currentSize;
    public size startingSize = size.HUMAN;
    public bool isChanging = false;

    private void Awake()
    {
        player = GetComponent<Player>();

        changeIncrement = (humanSize.x - bugSize.x) / scalingTimeSeconds; //only using the x value of the Vector3's since I need a single float and the values are the same
    }

    private void Start()
    {
        SetStartingSize((int)startingSize);
    }

    private void Update()
    {
        //References the input manager to determine if the input which changes the player's size has been activated.
        if (player.input.ChangingSize && !isChanging)
        {
            StartChange();
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

        if (changeTimer == 0)
        {
            isChanging = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ScaleChanger")
        {
            if (!isChanging)
            {
                changeTimer = scalingTimeSeconds;
                changeIncrement = -changeIncrement;

                if (currentSize == size.HUMAN)
                {
                    currentSize = size.BUG;
                    player.SetPlayerDataForSize((int)currentSize);
                }
                else
                {
                    currentSize = size.HUMAN;
                    player.SetPlayerDataForSize((int)currentSize);
                }

                isChanging = true;
            }
        }
    }

    public void StartChange()
    {
        isChanging = true;

        changeTimer = scalingTimeSeconds;
        changeIncrement = -changeIncrement;

        if (currentSize == size.HUMAN)
        {
            currentSize = size.BUG;
            player.SetPlayerDataForSize((int)currentSize);
        }
        else
        {
            currentSize = size.HUMAN;
            player.SetPlayerDataForSize((int)currentSize);
        }
    }

    public void SetStartingSize(int s)
    {
        //Takes the enum index as a parameter: 1 -- Human, 2 -- Bug
        if (s == 1)
        {
            transform.localScale = humanSize;
            currentSize = size.HUMAN;
            player.SetPlayerDataForSize(s);
        }
        else
        {
            transform.localScale = bugSize;
            currentSize = size.BUG;
            player.SetPlayerDataForSize(s);
        }
    }

}