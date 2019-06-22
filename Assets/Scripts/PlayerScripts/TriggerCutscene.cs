using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    private Moving script;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<PlayableDirector>().Play();
            script = other.GetComponent<Moving>();
            script.allowMovement = false;
            script.ZeroInputs();
            StartCoroutine(ResumeMoving());
        }
    }

    private IEnumerator ResumeMoving()
    {
        yield return new WaitForSeconds(5.5f);
        script.allowMovement = true;
        Destroy(gameObject);
    }
}
