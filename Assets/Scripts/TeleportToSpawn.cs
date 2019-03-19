using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Teleport(spawnPoints.GetChild(0));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Teleport(spawnPoints.GetChild(1));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Teleport(spawnPoints.GetChild(2));
        }
    }

    private void Teleport(Transform point)
    {
        transform.position = point.position;
    }
}
