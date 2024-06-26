using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemJump : StateMachineBehaviour
{
    float speed = 0;
    float jumpCoolDown = 2f;

    Vector2 player;
    Rigidbody2D golemRb;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        golemRb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform.position - new Vector3(0, 4);


        speed = Vector2.Distance(player, golemRb.position) / animator.GetCurrentAnimatorStateInfo(0).length;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var targer = Vector2.MoveTowards(golemRb.position, player, speed * Time.fixedDeltaTime);
        golemRb.MovePosition(targer);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
