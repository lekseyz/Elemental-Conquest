using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    Patroler patroler;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }

        patroler.setSpeed(Patroler.SpeedStates.Jump);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = patroler.toPlayerDistance;

        if (distance < patroler.detectionDistance)
            animator.SetTrigger("Run");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
    }
}
