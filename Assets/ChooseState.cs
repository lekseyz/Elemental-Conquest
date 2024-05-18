using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.Play("Slam");
        }
        else
        {
            animator.Play("Attack");
        }

    }
}
