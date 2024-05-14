using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }
        patroler.setSpeed(Patroler.SpeedStates.Stay);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler == null)
        {
            throw new System.Exception("Patroler cannot be null");
        }

        float distance = patroler.toTargetDistance;


        // Проверяем, если игрок не в зоне атаки, переходим в другое состояние
        if (distance > patroler.attackDistance)
        {
            animator.SetTrigger("Run");
        }
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
