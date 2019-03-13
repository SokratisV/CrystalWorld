using UnityEngine;

public class JumpForce : StateMachineBehaviour
{
    public float jumpForceDelay = .5f;
    public int jumpForce = 50;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.GetComponent<Moving>().JumpForce(jumpForceDelay, jumpForce);
    }
   
}
