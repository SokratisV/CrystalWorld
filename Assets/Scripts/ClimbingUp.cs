using UnityEngine;

public class ClimbingUp : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<Moving>().enabled = true;
    }
}
