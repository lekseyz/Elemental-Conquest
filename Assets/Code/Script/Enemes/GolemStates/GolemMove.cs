using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pointIdle : StateMachineBehaviour
{
    float speed = 3f;
    float jumpCoolDown = 3f;
    
    Transform player;
    Transform point;
    Rigidbody2D golem;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        golem = animator.gameObject.GetComponent<Rigidbody2D>();
        point = GameObject.FindGameObjectWithTag("point").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumpCoolDown -= Time.deltaTime;
        if (jumpCoolDown <= 0)
        {
            jumpCoolDown = 3;
            if (Vector2.Distance(point.position, player.position) > 1)
            {
                animator.SetTrigger("setJump");
            }
        }
        Debug.Log(Vector2.Distance(point.position, player.position));

        if(Vector2.Distance(point.position, player.position) < 4)
        {
            animator.SetTrigger("setAttack");
        }
        var target = Vector2.MoveTowards(golem.position, player.position, speed * Time.fixedDeltaTime);
        golem.MovePosition(target);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("setAttack");
        animator.ResetTrigger("setJump");
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
