using UnityEngine;

public class RunState : StateMachineBehaviour
{
    Patroler patroler;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }
        patroler.setPlayerTarget();
        patroler.setSpeed(Patroler.SpeedStates.Run);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }

        float distance = patroler.toTargetDistance;


        if (distance >= patroler.outOfReachDistance)
        {
            animator.SetTrigger("Idle");
        }
        else if (distance >= patroler.detectionDistance)
        {
            animator.SetTrigger("Jump");
        }
        else if (distance <= patroler.attackDistance)
        {
            animator.SetTrigger("Attack");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }
}
