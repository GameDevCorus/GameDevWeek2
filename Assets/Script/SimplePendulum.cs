using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float swingSpeed = 1f;     // W/S changes this
    public float amplitude = 3f;      // how wide the swing is
    public float curveSharpness = 1f; // how “smiley” the parabola is

    private Vector2 center;           // lowest point
    private float t = 0f;             // time counter

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        HandleTeleport();
        HandleSpeed();
        ApplyParabolaMotion();
    }

    void HandleTeleport()
    {
        if (Input.GetMouseButtonDown(0))
        {
            center = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            t = 0f;
        }
    }

    void HandleSpeed()
    {
        if (Input.GetKey(KeyCode.W))
            swingSpeed += 1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            swingSpeed -= 1f * Time.deltaTime;

        swingSpeed = Mathf.Max(0f, swingSpeed);
    }

    void ApplyParabolaMotion()
    {
        t += swingSpeed * Time.deltaTime;

        // x oscillates
        float x = Mathf.Sin(t) * amplitude;

        // y follows parabola based on x
        float y = curveSharpness * (x * x);

        transform.position = center + new Vector2(x, y);
    }
}
