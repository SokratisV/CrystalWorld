using UnityEngine;

public class Climbing : MonoBehaviour
{
    public bool allowClimbing = true;

    private Animator anim;
    private float InputX, InputZ;
    private WaitForSeconds delayRespawn = new WaitForSeconds(2f);
    private Rigidbody rb;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (allowClimbing)
        {
            InputX = Input.GetAxis("Horizontal");
            InputZ = Input.GetAxis("Vertical");

            // if (Input.GetKeyDown("space"))
            // {
            //     anim.SetTrigger("wallJump");
            //     anim.SetBool("isClimbing", false);
            //     //rb.velocity = Vector3.back * 10;
            // }
            PlayerClimb(InputX, InputZ);
        }
    }

    void PlayerClimb(float InputX, float InputZ)
    {
        anim.SetFloat("InputZ", InputZ);
        anim.SetFloat("InputX", InputX);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ClimbTop")
        {
            anim.SetBool("isClimbing", false);
            enabled = false;
        }
    }

    private void OnEnable()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        // GetComponent<CapsuleCollider>().height = 0;
    }
}
