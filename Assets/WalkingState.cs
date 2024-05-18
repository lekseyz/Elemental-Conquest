using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkingState : StateMachineBehaviour
{
    PatrolerKnight patroler;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patroler = animator.GetComponent<PatrolerKnight>();
        patroler.speed = 5;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float distance = patroler.targetDistance();

        patroler.walkToTarget();

        
        if (animator.GetBool("IsSpawning"))
        {
            checkSpawningStates(animator);
        } 
        else 
        {
            checkDefaultStates(animator);
        }
    }

    private void checkSpawningStates(Animator animator)
    {
        float distance = patroler.targetDistance();

        if (patroler.chainicsCount == 3)
        {
            animator.SetBool("IsSpawning", false);
            patroler.setPlayerPoint();
            return;   
        }
        if(distance < 1)
        {
            animator.SetTrigger("Ranged");
            patroler.setFarestPoint();
            return;
        }
    }

    private void checkDefaultStates(Animator animator)
    {
        float distance = patroler.targetDistance();

        if (distance < 2)
        {
            animator.SetTrigger("CloseAttack");
        }
        else if (distance > 6 && patroler.canSpawn && patroler.columnCanSpawn)
        {
            animator.SetBool("IsSpawning", true);
            animator.SetTrigger("Ranged");
            patroler.setFarestPoint();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
