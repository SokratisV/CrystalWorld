using UnityEngine;

public class AdjustHeight : MonoBehaviour
{
    private Rigidbody rb;
    private int force;

    void Start()
    {
        force = 110;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.up * force);
    }
}
