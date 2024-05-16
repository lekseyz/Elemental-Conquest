using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpike : StateMachineBehaviour
{
    PatrolerKnight patroler;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<PatrolerKnight>();
        patroler.speed = 0;
        patroler.SPAWNCHAINIC();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Walk");
        animator.ResetTrigger("SpikeAttack");
    }
}
