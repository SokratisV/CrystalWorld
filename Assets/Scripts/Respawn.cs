using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            transform.position = respawnPoint.position;
        }
    }
}
