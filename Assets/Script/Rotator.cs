using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 180f; // degrees per second

    void Update()
    {
        // Rotate around its own Z axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
