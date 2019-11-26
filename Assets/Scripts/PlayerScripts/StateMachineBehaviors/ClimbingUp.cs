﻿using UnityEngine;

public class ClimbingUp : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.rotation = Quaternion.Euler(0, -81, 0);
        animator.transform.position = animator.transform.position + new Vector3(-.1f, 0, 0);
    }

    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     animator.transform.GetComponent<Moving>().enabled = true;
    // }
}