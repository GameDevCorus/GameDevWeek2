using UnityEngine;

public class LineSwing : MonoBehaviour
{
    public float speed = 1f;

    private Vector2 center;      // active center
    private Vector2 dir;         // active direction
    private float travelDist;    // active distance

    private Vector2 pendingDir;      // new direction on click
    private float pendingDist;       // new distance on click
    private bool hasPending = false; // Pending New Direction

    private float t = 0f;        // drives sin wave

    void Start()
    {
        center = transform.position;
        dir = Vector2.right;    // default direction
        travelDist = 1f;        // default distance
    }

    void Update()
    {
        HandleSpeed();
        HandleMouse();
        ApplyMotion();
    }

    void HandleSpeed()
    {   
        //Change speed W/S
        if (Input.GetKey(KeyCode.W)) speed += Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) speed -= Time.deltaTime;

        speed = Mathf.Max(0.1f, speed);
    }

    //New direction by mouse click
    void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 newDir = (mouse - center).normalized;
            float newDist = Vector2.Distance(center, mouse);

            // save for later — but do NOT apply yet
            pendingDir = newDir;
            pendingDist = newDist;
            hasPending = true;
        }
    }

    void ApplyMotion()
    {
        t += speed * Time.deltaTime;
        float range = Mathf.Sin(t);

        // If we are at the center (the sin wave crosses 0)…
        if (hasPending && WithinZeroCross(range))
        {
            // Apply new center + direction + distance
            center = transform.position;        // new center is current position
            dir = pendingDir;
            travelDist = pendingDist;

            hasPending = false;

            // Reset cycle so next swing starts cleanly
            t = 0f;
        }

        transform.position = center + dir * (range * travelDist);
    }

    //Determine "finish" of current pendulum
    bool WithinZeroCross(float v)
    {
        // close enough to 0 to count as returning to center
        return Mathf.Abs(v) < 0.01f;
    }
}
