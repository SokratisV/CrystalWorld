using System.Collections;
using UnityEngine;

public class TigerScript : MonoBehaviour {

    public GameObject player;
    public Transform startingTransform;
    public float speed = 9;
    public float distanceToKill;
    public GameObject pinkCrystal;

    private Animator anim;
    private float damping;
    private bool hasCoroutineStarted = false;
    private float distance;
    private bool playOtherAnimations = true;
    private float i;
    private bool isPositionReset = true;
    private bool killedTarget = false;

	void Start () {
        anim = GetComponent<Animator>();
        damping = 1f;
	}
	void Update () {
        distance = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position));
        if (pinkCrystal.activeSelf)
        {
            if (!killedTarget)
            {
                Behaviour();
            }
            else
            {
                ReturnBack();
            }
        }
        else
        {
            StartCoroutine(RandomIdleToSound());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && !hasCoroutineStarted)
        {
            anim.Play("idle");
            StartCoroutine(HitAnimation());
        }
    }
    private void Behaviour()
    {
        if (distance <= 25 && playOtherAnimations)
        {
            anim.Play("run");
            isPositionReset = false;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * damping * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), .9f);
        }
        else if (distance > 25 && playOtherAnimations)
        {        
            if (isPositionReset)
            {
                if (!hasCoroutineStarted)
                {
                    StartCoroutine(RandomIdleToSound());
                }
            }
            else
            {
                killedTarget = true;
            }
            
        }
    }
    private void ReturnBack()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, startingTransform.position)) <= 1f)
        {
            anim.Play("idle");
            isPositionReset = true;
            killedTarget = false;
        }
        else
        {
            anim.Play("run");
            transform.position = Vector3.MoveTowards(transform.position, startingTransform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(startingTransform.position - transform.position), .9f);
        } 
    }
    private IEnumerator RandomIdleToSound()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(3);
        i = Random.Range(0.0f, 1.0f);
        if (i <= 0.3f)
        {
            anim.Play("sound");
        }
        else
        {
            anim.Play("idle");
        }
        hasCoroutineStarted = false;
    }
    private IEnumerator HitAnimation()
    {
        anim.Play("hit");
        hasCoroutineStarted = true;
        playOtherAnimations = false;
        yield return new WaitForSeconds(1.2f);
        killedTarget = true;
        playOtherAnimations = true;
        hasCoroutineStarted = false;
    }
}
