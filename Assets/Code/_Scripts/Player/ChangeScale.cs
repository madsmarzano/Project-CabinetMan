using UnityEngine;

public class ChangeScale : MonoBehaviour
{
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
        HUMAN,
        BUG
    }

    public size currentSize;
    public bool hasChanged = false;

    private void Awake()
    {
        transform.localScale = humanSize;

        changeIncrement = (humanSize.x - bugSize.x) / scalingTimeSeconds; //only using the x value of the Vector3's since I need a single float and the values are the same
    }

    private void Update()
    {
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
            hasChanged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ScaleChanger")
        {
            if (!hasChanged)
            {
                changeTimer = scalingTimeSeconds;
                changeIncrement = -changeIncrement;

                if (currentSize == size.HUMAN)
                    currentSize = size.BUG;
                else
                    currentSize = size.HUMAN;

                hasChanged = true;
            }
        }
    }

}