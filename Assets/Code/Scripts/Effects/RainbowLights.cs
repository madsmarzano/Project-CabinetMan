using UnityEngine;

public class RainbowLights : MonoBehaviour

{
    public Light lightObject; // Reference to the light component

    float hue = 0f; // Starting hue value

    [Range(0f, 0.5f)]
    public float speed = 0.5f; // Speed of color change

    void Update()

    {

        // Increment hue value

        hue += speed * Time.deltaTime;



        // Cycle hue if it goes beyond 1

        if (hue > 1f)

        {

            hue -= 1f;

        }



        // Convert hue to RGB color

        Color rainbowColor = HSVToRGB(hue, 1f, 1f);



        // Set light color

        lightObject.color = rainbowColor;

    }



    // Helper function to convert HSV to RGB

    Color HSVToRGB(float h, float s, float v)

    {

        int i = Mathf.FloorToInt(h * 6);

        float f = h * 6 - i;

        float p = v * (1 - s);

        float q = v * (1 - f * s);

        float t = v * (1 - (1 - f) * s);



        switch (i % 6)

        {

            case 0: return new Color(v, t, p);

            case 1: return new Color(q, v, p);

            case 2: return new Color(p, v, t);

            case 3: return new Color(p, q, v);

            case 4: return new Color(t, p, v);

            case 5: return new Color(v, p, q);

            default: return Color.black;

        }

    }

}
