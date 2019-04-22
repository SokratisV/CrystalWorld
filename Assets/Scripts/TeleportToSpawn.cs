﻿using System.Collections;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject player;
    public GameObject cinemachineVCam;
    public GameObject shipMenuUI;
    public GameObject[] seaSoundObjects;

    private WaitForSeconds delay = new WaitForSeconds(0.25f);
    private Transform lastSpawnPoint;

    private void Start()
    {
        SetLastSpawn(0);
        RespawnDebug();
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
        StartCoroutine(TurnOffMenu());
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
    private IEnumerator TurnOffMenu()
    {
        yield return delay;
        cinemachineVCam.SetActive(true);
        shipMenuUI.SetActive(false);
    }
}
