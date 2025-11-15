using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public DistanceJoint2D joint;
    public Transform ropeAnchor;  // A GameObject in the scene representing where the rope is attached

    void Start()
    {
        // Set the rope anchor position
        joint.connectedAnchor = ropeAnchor.position;
        joint.enabled = true;

        //Set rope length equal to current distance
        joint.distance = Vector2.Distance(transform.position, ropeAnchor.position);

        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // Line from anchor → ball
        lineRenderer.SetPosition(0, ropeAnchor.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}
