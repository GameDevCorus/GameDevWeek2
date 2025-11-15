using UnityEngine;

public class BallPulse : MonoBehaviour
{
    public float minScale = 0.5f;      // base smallest size
    public float maxScale = 1.5f;      // base largest size
    public float speed = 1f;           // pulsing speed

    public float sizeChangeSpeed = 0.5f; // how fast W/S changes size

    private float t = 0f;

    void Update()
    {
        // W/S adjust speed
        if (Input.GetKey(KeyCode.W)) speed += Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) speed -= Time.deltaTime;
        speed = Mathf.Max(0.1f, speed);

        // W/S also adjust size range
        if (Input.GetKey(KeyCode.W))
        {
            maxScale += sizeChangeSpeed * Time.deltaTime;
            minScale += sizeChangeSpeed * Time.deltaTime * 0.5f; // min grows slower
        }

        if (Input.GetKey(KeyCode.S))
        {
            maxScale -= sizeChangeSpeed * Time.deltaTime;
            minScale -= sizeChangeSpeed * Time.deltaTime * 0.5f;
        }

        // clamp sizes so min never exceeds max
        minScale = Mathf.Clamp(minScale, 0.1f, maxScale - 0.1f);
        maxScale = Mathf.Max(maxScale, minScale + 0.1f);

        // increment time for smooth pulsing
        t += speed * Time.deltaTime;

        float scaleFactor = (Mathf.Sin(t) + 1f) / 2f;
        float scale = Mathf.Lerp(minScale, maxScale, scaleFactor);

        transform.localScale = new Vector3(scale, scale, scale);
    }
}
