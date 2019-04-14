﻿using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GetComponent<TeleportToSpawn>().DeathRespawn();
        }
        else if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }
}