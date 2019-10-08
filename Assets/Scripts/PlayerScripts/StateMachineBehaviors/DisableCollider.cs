using UnityEngine;

public class DisableCollider : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<CapsuleCollider>().enabled = false;        
    }
}
