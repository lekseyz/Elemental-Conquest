using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GolemIdle : StateMachineBehaviour
{
    float speed = 0f;
    float jumpCoolDown = 5;
    
    Transform player;
    Rigidbody2D golemRb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        golemRb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //jumpCoolDown -= Time.deltaTime;
        //if(jumpCoolDown <= 0)
        //{
        //    jumpCoolDown = 5;
        //    if (Vector2.Distance(golemRb.position, player.position) > 5)
        //    {
        //        animator.SetTrigger("setJump");
        //    }
        //}

        if(Vector2.Distance(golemRb.position, player.position) < 5)
        {
            animator.SetTrigger("setAttack");
        }
        var targer = Vector2.MoveTowards(golemRb.position, player.position, speed * Time.fixedDeltaTime);
        golemRb.MovePosition(targer);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("setAttack");
        //animator.ResetTrigger("setJump");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
