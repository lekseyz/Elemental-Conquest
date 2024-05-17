using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : StateMachineBehaviour
{
    PatrolerKnight patroler;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("RandomAttack", Random.Range(0, 1.0f));

        patroler = animator.GetComponent<PatrolerKnight>();
        patroler.speed = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = patroler.targetDistance();


        if (distance > 3)
        {
            animator.SetTrigger("Walk");
        }
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("CloseAttack");
    }
}
