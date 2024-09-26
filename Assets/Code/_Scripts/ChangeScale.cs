using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public Vector3 humanSize = Vector3.one;
    public Vector3 bugSize = new Vector3(0.25f, 0.25f, 0.25f);

    public Vector3 positionChange = new Vector3(0, 0.75f, 0); //Changes player position on the y axis relative to size to ensure Player remains grounded.

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ScaleChanger")
        {
            if (!hasChanged)
            {
                if (currentSize == size.HUMAN)
                {
                    transform.localScale = bugSize;
                    transform.position -= positionChange;
                    currentSize = size.BUG;
                }
                else
                {
                    transform.localScale = humanSize;
                    transform.position += positionChange;
                    currentSize = size.HUMAN;
                }

                hasChanged = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ScaleChanger")
        {
            //hasChanged = false;
        }
    }

}
