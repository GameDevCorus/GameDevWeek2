using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [Header("References")]
    public Transform player;       // Scene player
    public RectTransform icon;     // Player icon (UI Image)
    public RectTransform mapArea;  // Mini-map background

    [Header("Settings")]
    public float worldSize = 20f;  // How many world units fit inside mini-map
    public bool rotateIcon = true; // Rotate icon with player

    private float halfMapSize;

    void Start()
    {
        if (player == null || icon == null || mapArea == null)
        {
            Debug.LogError("Assign player, icon, and mapArea in MiniMap script.");
            enabled = false;
            return;
        }

        if (icon.parent != mapArea)
            icon.SetParent(mapArea, false);

        // Half of the mini-map background size (square)
        halfMapSize = mapArea.rect.width / 2f;
    }

    void LateUpdate()
    {
        // Convert world position to mini-map coordinates
        Vector2 offset = new Vector2(player.position.x, player.position.y) * (halfMapSize / worldSize);

        // Clamp inside mini-map
        offset.x = Mathf.Clamp(offset.x, -halfMapSize, halfMapSize);
        offset.y = Mathf.Clamp(offset.y, -halfMapSize, halfMapSize);

        // Move icon relative to mapArea (center of map)
        icon.anchoredPosition = offset;

        // Rotate icon with player
        if (rotateIcon)
            icon.localRotation = Quaternion.Euler(0f, 0f, -player.eulerAngles.z);
    }
}
