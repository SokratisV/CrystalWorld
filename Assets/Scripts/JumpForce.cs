using UnityEngine;

public class JumpForce : StateMachineBehaviour
{
    public float jumpForceDelay;
    public int jumpForce;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<Moving>().JumpForce(jumpForceDelay, jumpForce);
    }
   
}
