using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnState : StateMachineBehaviour
{
    PatrolerKnight patroler;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<PatrolerKnight>();

        patroler.SpawnColumns();
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsSpawning", false);
        patroler.setPlayerPoint();
    }
}
