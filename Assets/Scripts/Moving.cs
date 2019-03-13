using System.Collections;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float desiredRotationSpeed;
    public Camera cam;
    public int jumpForce = 50, glideForce = 1500;

    private Animator anim;
    private float InputX, InputZ, distanceToTheGround = 1.7f;
    private Vector3 moveVector, desiredMoveDirection, forward, right;
    private WaitForSeconds delayAnimation = new WaitForSeconds(0.1f);
    private WaitForSeconds delayRespawn = new WaitForSeconds(2f);
    private Rigidbody rb;
    private bool coroutineStarted, allowAnimation, canClimb, airGlide = false;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        if (cam == null)
        {
            cam = Camera.main;
        }
        coroutineStarted = false;
        allowAnimation = true;
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

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
            if (timer > 0.5f)
            {
                if (allowAnimation)
                {
                    anim.SetBool("falling", true);
                }
            }
            airGlide = true;
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("jump");
        }
    }

    private void FixedUpdate()
    {
        if (airGlide)
        {
            forward = cam.transform.forward;
            right = cam.transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();
            desiredMoveDirection = forward * InputZ + right * InputX;

            if (InputZ > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            }
            rb.AddForce(forward * glideForce);
        }
    }

    private bool Grounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanceToTheGround))
        {
            timer = 0f;
            canClimb = true;
            airGlide = false;
            return true;
        }
        else
        {
            timer += Time.deltaTime;
            return false;
        }
    }

    void PlayerMoveAndRotation(float InputX, float InputZ)
    {
        forward = cam.transform.forward;
        right = cam.transform.right;
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "ClimbBottom" && canClimb)
        {
            StartCoroutine(TemporaryDisable(collision));
            canClimb = false;
            GetComponent<Climbing>().enabled = true;
            anim.SetBool("isClimbing", true);
            enabled = false;
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

    public void ZeroInputs()
    {
        InputZ = 0f;
        InputX = 0f;
        anim.SetFloat("InputZ", 0f);
        anim.SetFloat("InputX", 0f);
    }

    private void OnEnable()
    {
        rb.useGravity = true;
    }

    public void JumpForce(float delay, int force)
    {
        StartCoroutine(_JumpForce(delay,force));
    }

    private IEnumerator _JumpForce(float delay, int force)
    {
        yield return new WaitForSeconds(delay);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

}
