using UnityEngine;

public class AdjustCollider : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AdjustColliderSize>().enabled = true;
    }
}
