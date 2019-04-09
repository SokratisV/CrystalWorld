using System.Collections;
using UnityEngine;

public class RhinoSleep : MonoBehaviour
{
    public GameObject food;

    private Vector3 lookPosition;
    private Quaternion rotation;
    private Rigidbody rb;
    private Animator anim;
    private WaitForSeconds delay;
    private bool reachedFood = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        delay = new WaitForSeconds(5f);
    }

    private void FixedUpdate()
    {
        if (!reachedFood)
        {
            lookPosition = food.transform.position - transform.position;
            lookPosition.y = 0;
            rotation = Quaternion.LookRotation(lookPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 3);
            ResetAnimatorParams();
            anim.SetBool("Walking", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.Contains("Steak"))
        {
            reachedFood = true;
            StartCoroutine(EatAndSleep());
        }
    }

    private void ResetAnimatorParams()
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }    
    }
    private IEnumerator EatAndSleep()
    {
        anim.SetBool("Walking", false);
        anim.SetBool("Eating", true);
        yield return delay;
        anim.SetBool("Eating", false);
        anim.SetTrigger("Sleeping");
        food.SetActive(false);
        Destroy(this);
    }
}
