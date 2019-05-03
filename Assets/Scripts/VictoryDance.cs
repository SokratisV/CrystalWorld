using UnityEngine;

public class VictoryDance : MonoBehaviour
{
    public Transform placeToDance;

    public void Victory()
    {
        transform.position = placeToDance.position;
        transform.rotation = placeToDance.rotation;

        if (tag == "Player")
        {
            GetComponent<Moving>().allowMovement = false;
        }
        GetComponent<Animator>().SetTrigger("Dancing");
    }
}
