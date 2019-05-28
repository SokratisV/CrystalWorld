using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float allowPlayerRotation, desiredRotationSpeed;
    public Camera cam;

    private Animator anim;
    private float InputX, InputZ, distanceToTheGround = 1.7f;
    private Vector3 moveVector, desiredMoveDirection;
    private WaitForSeconds delayAnimation = new WaitForSeconds(0.1f);
    private WaitForSeconds delayRespawn = new WaitForSeconds(2f);
    private Rigidbody rb;
    private bool coroutineStarted, allowAnimation, moving = true, climbing = false;
    private float timer;

    void Start()
    {
        allowPlayerRotation = .1f;
        desiredRotationSpeed = 1.5f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        coroutineStarted = false;
        allowAnimation = true;
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        if (moving)
        {
            if (Grounded())
            {
                anim.SetBool("falling", false);
                if (!coroutineStarted)
                {
                    allowAnimation = false;
                    coroutineStarted = true;
                    StartCoroutine(DelayAnimation());
                }
                PlayerMoveAndRotation(InputX, InputZ);
            }
            else
            {
                if (allowAnimation)
                {
                    anim.SetBool("falling", true);
                }
            }
        }
        else if (climbing)
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("wallJump");
                anim.SetBool("isClimbing", false);
            }
            PlayerClimb(InputX, InputZ);
        }
    }

    private bool Grounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanceToTheGround))
        {
            timer = 0f;
            return true;
        }
        else
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 6f)
            {
                rb.AddForce(Vector3.back);
            }
            return false;
        }
    }

    void PlayerMoveAndRotation(float InputX, float InputZ)
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        anim.SetFloat("InputZ", InputZ);
        anim.SetFloat("InputX", InputX);

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        desiredMoveDirection = forward * InputZ + right * InputX;

        if (InputZ > 0 && InputX == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
        else if (InputZ < 0 && InputX == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-desiredMoveDirection), desiredRotationSpeed);
        }

    }

    void PlayerClimb(float InputX, float InputZ)
    {
        anim.SetFloat("InputZ", InputZ);
        anim.SetFloat("InputX", InputX);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ClimbObject")
        {
            StartCoroutine(TemporaryDisable(collision));
            if (climbing == false)
            {
                ActivateState("climbing");
                anim.SetBool("isClimbing", true);
            }
            else
            {
                anim.SetBool("isClimbing", false);
            }
        }
    }

    private IEnumerator DelayAnimation()
    {
        yield return delayAnimation;
        coroutineStarted = false;
        allowAnimation = true;
    }

    private IEnumerator TemporaryDisable(Collider collider)
    {
        collider.enabled = false;
        yield return delayRespawn;
        collider.enabled = true;
    }

    public void ActivateState(string state)
    {
        if (state == "moving")
        {
            Debug.Log("Now moving");
            rb.useGravity = true;
            climbing = false;
            moving = true;
        }
        else if (state == "climbing")
        {
            Debug.Log("Now climbing");
            rb.useGravity = false;
            climbing = true;
            moving = false;
        }
    }
}
