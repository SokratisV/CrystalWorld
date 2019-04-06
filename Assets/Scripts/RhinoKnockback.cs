﻿using System.Collections;
using UnityEngine;

public class RhinoKnockback : MonoBehaviour
{
    public Transform rhinoKnockbackLocation;

    private float timeToMove = 30f;
    private float timer;
    
    public void TriggerKnockBack()
    {
        timer = 0f;
        GetComponent<Animator>().SetTrigger("knockBack");
        StartCoroutine(KnockBack());
    }

    private IEnumerator KnockBack()
    {
        while  (timer < .1)
        {
            timer += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(transform.position, rhinoKnockbackLocation.position, timer);
            yield return null;
        }
    }
}