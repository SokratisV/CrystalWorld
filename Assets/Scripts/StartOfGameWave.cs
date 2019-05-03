using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class StartOfGameWave : MonoBehaviour
{
    private Moving script;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("WaveStop");
            collision.gameObject.GetComponent<Animator>().SetTrigger("Wave");
            GetComponent<PlayableDirector>().Play();
            script = collision.transform.GetComponent<Moving>();
            script.allowMovement = false;
            script.ZeroInputs();
            StartCoroutine(ResumeMoving());
            GetComponent<BoxCollider>().size = new Vector3(1,2,1);
            GetComponent<BoxCollider>().center = new Vector3(0, 1, 0);
            Destroy(this);
        }
    }

    private IEnumerator ResumeMoving()
    {
        yield return new WaitForSeconds(5.5f);
        script.allowMovement = true;
    }
}
