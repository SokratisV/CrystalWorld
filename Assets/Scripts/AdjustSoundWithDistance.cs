﻿using UnityEngine;

public class AdjustSoundWithDistance : MonoBehaviour
{
    public Transform player;
    
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
    }
}
