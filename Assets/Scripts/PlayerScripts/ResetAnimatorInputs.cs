using UnityEngine;

public class ResetAnimatorInputs : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.GetComponent<Moving>().ZeroInputs();
    }
}
