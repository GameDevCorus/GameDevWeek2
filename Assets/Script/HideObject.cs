using UnityEngine;

public class HideObject : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        // Get the SpriteRenderer component attached to current GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Warn if no SpriteRenderer is found
        if (spriteRenderer == null)
        {
            Debug.LogWarning("No SpriteRenderer found on " + gameObject.name);
        }
    }

    void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            // Toggle visibility 
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }
}
