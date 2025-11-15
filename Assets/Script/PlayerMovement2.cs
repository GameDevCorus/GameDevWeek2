using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // WASD / Arrow keys input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void FixedUpdate()
    {
        // Move player
        Vector2 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Get camera bounds
        Camera cam = Camera.main;
        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float minX = cam.transform.position.x - horzExtent;
        float maxX = cam.transform.position.x + horzExtent;
        float minY = cam.transform.position.y - vertExtent;
        float maxY = cam.transform.position.y + vertExtent;

        // Clamp position inside camera view
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        rb.MovePosition(newPos);
    }
}
