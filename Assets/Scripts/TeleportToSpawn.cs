using System.Collections;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject player;
    public GameObject cinemachineVCam;
    public GameObject questionsMenuUI;

    private WaitForSeconds delay = new WaitForSeconds(0.25f);
    private Transform lastSpawnPoint;

    private void Start()
    {
        SetLastSpawn(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Respawn(0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Respawn(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Respawn(2);
        }
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

    public void Respawn(int point)
    {
        print("Respawning");
        Teleport(spawnPoints.GetChild(point));
        GetComponent<GameManagement>().Pause();
        StartCoroutine(TurnOffMenu());
    }

    private IEnumerator TurnOffMenu()
    {
        yield return delay;
        cinemachineVCam.SetActive(true);
        print("I'm in");
        questionsMenuUI.SetActive(false);
    }
}
