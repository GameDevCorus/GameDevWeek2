using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedHorizontalCamera : MonoBehaviour
{
    public float targetWidth = 16f; // world units visible horizontally
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
    }

    void LateUpdate()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        cam.orthographicSize = targetWidth / (2f * screenRatio);
    }
}
