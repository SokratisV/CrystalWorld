using UnityEngine;

public class EnableCollider : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.GetComponent<Rigidbody>().isKinematic = false;
        animator.transform.GetComponent<CapsuleCollider>().enabled = true;
        animator.transform.GetComponent<Moving>().enabled = true;
    }
}
