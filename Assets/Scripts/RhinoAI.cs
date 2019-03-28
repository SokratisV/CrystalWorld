using System.Collections;
using UnityEngine;

public class RhinoAI : MonoBehaviour
{
    public GameObject player;
    public GameObject crystal;
    public float attackDistance = 5f;
    public GameObject eatingPlaces;
    
    private float distance;
    private Animator anim;
    private Vector3 lookPosition;
    private Quaternion rotation;
    private Rigidbody rb;
    private int index = 0;
    private WaitForSeconds eatingTime = new WaitForSeconds(4f);
    private bool playerKilled = false;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.SetBool("Walking", true);
    }

    void FixedUpdate()
    {
        Vector3 playerTransform = player.transform.position;
        distance = (playerTransform - transform.position).sqrMagnitude;

        if (distance < attackDistance * attackDistance)
        {
            if (!playerKilled)
            {
                lookPosition = player.transform.position - transform.position;
                lookPosition.y = 0;
                rotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 4);
                anim.SetBool("Chasing", true);
            }
        }
        else
        {
            if (anim.GetBool("Walking"))
            {
                lookPosition = eatingPlaces.transform.GetChild(index).transform.position - transform.position;
                lookPosition.y = 0;
                rotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(KillPlayer());
            collision.gameObject.GetComponent<TeleportToSpawn>().Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Eat());
    }

    private void AdvanceIndex()
    {
        if (index + 1 == eatingPlaces.transform.childCount)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    private IEnumerator Eat()
    {
        anim.SetBool("Walking", false);
        anim.SetBool("Eating", true);
        yield return eatingTime;
        anim.SetBool("Eating", false);
        anim.SetBool("Idle", true);
        yield return eatingTime;
        anim.SetBool("Walking", true);
        anim.SetBool("Idle", false);
        AdvanceIndex();
    }

    private IEnumerator KillPlayer()
    {
        anim.SetBool("Chasing", false);
        anim.SetBool("Walking", false);
        anim.Play("shout");
        playerKilled = true;
        yield return eatingTime;
        playerKilled = false;
        anim.SetBool("Walking", true);
    }

    private void ResetAnimatorParameters()
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }
    }
}
