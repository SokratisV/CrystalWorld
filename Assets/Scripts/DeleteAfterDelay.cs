using System.Collections;
using UnityEngine;

public class DeleteAfterDelay : MonoBehaviour
{
    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(5f);
        StartCoroutine(DelayedDestruction());
    }

    private IEnumerator DelayedDestruction()
    {
        yield return delay;
        Destroy(gameObject);
    }
}
