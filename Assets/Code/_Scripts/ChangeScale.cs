using UnityEngine;

/// <summary>
/// By Mads :
/// Currently changes the scale of the player when a trigger is activated.
/// The method of changing this scale will likely change.
/// </summary>

public class ChangeScale : MonoBehaviour
{
    public Vector3 humanSize = Vector3.one;
    public Vector3 bugSize = new Vector3(0.25f, 0.25f, 0.25f);

    [Tooltip("The amount of frames it takes to complete the process of gradually changing from one size to the other.")]
    public int totalScalingFrames = 200;
    [Tooltip("Counter variable used in the update method during the scale-change process.")]
    private int scalingFramesLeft = 0;
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

        changeIncrement = (humanSize.x - bugSize.x) / totalScalingFrames; //only using the x value of the Vector3's since I need a single float and the values are the same
    }

    private void Update()
    {
        if (scalingFramesLeft > 0)
        {
            transform.localScale += new Vector3(changeIncrement, changeIncrement, changeIncrement);
            transform.position += new Vector3(0, changeIncrement, 0);
            scalingFramesLeft--;
        }

        if (scalingFramesLeft == 0)
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
                scalingFramesLeft = 200;
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
