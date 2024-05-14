using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private float idleTime = 1.0f; // Минимальное время в состоянии покоя
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }
        
        patroler.setSpeed(Patroler.SpeedStates.Idle);
        patroler.setRandPointTarget();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }

        float distanceTarget = patroler.toTargetDistance;
        float distancePlayer = patroler.toPlayerDistance;

        if(distancePlayer < patroler.detectionDistance) { animator.SetTrigger("Run"); }
        if (distanceTarget < 1) { patroler.setRandPointTarget(); }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}
