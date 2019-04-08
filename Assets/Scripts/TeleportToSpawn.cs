using System.Collections;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject player;
    public GameObject cinemachineVCam;
    public GameObject shipMenuUI;

    private WaitForSeconds delay = new WaitForSeconds(0.25f);
    private Transform lastSpawnPoint;

    private void Start()
    {
        SetLastSpawn(0);
    }
    private void Teleport(Transform point)
    {
        cinemachineVCam.SetActive(false);
        player.transform.position = point.position;
    }
    public void SetLastSpawn(int spawnNumber)
    {
        if (spawnNumber >= spawnPoints.childCount || spawnNumber < 0)
        {
            spawnNumber = 0;
        }
        lastSpawnPoint = spawnPoints.GetChild(spawnNumber);
    }
    private void RespawnDebug()
    {
        transform.position = lastSpawnPoint.position;
    }
    public void DeathRespawn()
    {
        Teleport(spawnPoints.GetChild(0));
    }
    public void Respawn(int point)
    {
        Teleport(spawnPoints.GetChild(point));
        GetComponent<GameManagement>().Pause();
        StartCoroutine(TurnOffMenu());
    }
    private IEnumerator TurnOffMenu()
    {
        yield return delay;
        cinemachineVCam.SetActive(true);
        print("I'm in");
        shipMenuUI.SetActive(false);
    }
}
