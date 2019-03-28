using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;
    private Transform lastSpawnPoint;

    private void Start()
    {
        SetLastSpawn(0);
    }

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

    public void SetLastSpawn(int spawnNumber)
    {
        if (spawnNumber >= spawnPoints.childCount || spawnNumber < 0)
        {
            spawnNumber = 0;
        }
        lastSpawnPoint = spawnPoints.GetChild(spawnNumber);
    }

    public void Respawn()
    {
        transform.position = lastSpawnPoint.position;
    }
}
