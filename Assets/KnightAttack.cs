using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnightAttack : StateMachineBehaviour
{
    PatrolerKnight patroler;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<PatrolerKnight>();
        patroler.speed = 0;
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("CloseAttack");
    }
}
