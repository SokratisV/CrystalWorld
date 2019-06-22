using System.Collections;
using UnityEngine;

public class Eaten : MonoBehaviour
{
    private WaitForSeconds respawnTimer = new WaitForSeconds(15f);

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Respawn());    
    }

    private IEnumerator Respawn()
    {
        GetComponent<Collider>().enabled = false;
        yield return respawnTimer;
        GetComponent<Collider>().enabled = true;
    }
}
