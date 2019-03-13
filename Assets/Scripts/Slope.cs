using UnityEngine;

public class Slope : MonoBehaviour
{
    private bool isGrounded; // is on a slope or not
    public float slideFriction = 0.3f; // ajusting the friction of the slope
    private Vector3 hitNormal; //orientation of the slope.
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded)
        {
            //m_MoveDir.x += (1f - hitNormal.y) * hitNormal.x * (speed - slideFriction);
            //m_MoveDir.z += (1f - hitNormal.y) * hitNormal.z * (speed - slideFriction);
        }
        isGrounded = Vector3.Angle(Vector3.up, hitNormal) <= controller.slopeLimit;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }
}
