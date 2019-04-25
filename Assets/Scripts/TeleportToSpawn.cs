using System.Collections;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;
    public Transform debugSpawnPoints;
    public GameObject player;
    public GameObject cinemachineVCam;
    public GameObject shipMenuUI;
    public GameObject[] seaSoundObjects;
    public GameObject vCameras;
    //public Cinemachine.CinemachineVirtualCamera village; 
    //public Cinemachine.CinemachineVirtualCamera forest; 
    //public Cinemachine.CinemachineVirtualCamera maze; 

    private WaitForSeconds delay = new WaitForSeconds(0.25f);
    private Transform lastSpawnPoint;
    private Cinemachine.CinemachineFreeLook cameraScript;

    private void Start()
    {
        SetLastSpawn(0);
        RespawnDebug();
        cameraScript = cinemachineVCam.GetComponent<Cinemachine.CinemachineFreeLook>();
    }
    private void Teleport(Transform point)
    {
        cinemachineVCam.SetActive(false);
        vCameras.SetActive(false);
        player.transform.position = point.position;
        player.transform.rotation = point.rotation;
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
        player.transform.position = lastSpawnPoint.position;
        cinemachineVCam.SetActive(false);
        cinemachineVCam.SetActive(true);
    }
    public void DeathRespawn()
    {
        Teleport(spawnPoints.GetChild(0));
        cinemachineVCam.SetActive(true);
    }
    public void Respawn(int point)
    {
        Teleport(spawnPoints.GetChild(point));
        GetComponent<GameManagement>().ToggleShipUI();
        GetComponent<GameManagement>().currentArea = point;
        StartCoroutine(TurnOffMenu(point));
        for (int i = 0; i < seaSoundObjects.Length; i++)
        {
            if (i == point)
            {
                seaSoundObjects[i].SetActive(true);
            }
            else
            {
                seaSoundObjects[i].SetActive(false);
            }
        }
    }
    private IEnumerator TurnOffMenu(int point)
    {
        yield return delay;
        cinemachineVCam.SetActive(true);
        vCameras.SetActive(true);
        switch (point)
        {
            case 0:
                cameraScript.m_XAxis.Value = -91.3f;
                cameraScript.m_YAxis.Value = 0.36f;
                break;
            case 1:
                cameraScript.m_XAxis.Value = -151f;
                cameraScript.m_YAxis.Value = 0.4f;
                break;
            case 2:
                cameraScript.m_XAxis.Value = -75;
                cameraScript.m_YAxis.Value = 0.37f;
                break;
            default:
                break;
        }
    }
}
