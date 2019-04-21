using System.Collections;
using UnityEngine;

public class StartOfGameWave : MonoBehaviour
{
    private WaitForSeconds delay;
    [HideInInspector]
    public Coroutine coroutine;

    private void Start()
    {
        delay = new WaitForSeconds(3f);
        coroutine = StartCoroutine(WaveAfterDelay());
    }

    private IEnumerator WaveAfterDelay()
    {
        while (true)
        {
            yield return delay;
            GetComponentInChildren<Animator>().SetTrigger("Wave");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Wave");
            Destroy(this);
        }
    }
}
