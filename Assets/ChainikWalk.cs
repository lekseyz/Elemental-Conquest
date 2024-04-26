using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainikWalk : StateMachineBehaviour
{
    float jumpCoolDown = 2f;
    float speed = 3f;

    Transform player;
    Rigidbody2D chainik;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").transform;
        chainik = animator.gameObject.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jumpCoolDown -= Time.deltaTime;
        if (jumpCoolDown <= 0)
        {
            jumpCoolDown = 2f;
            if (Vector2.Distance(chainik.transform.position, player.transform.position)<20)
                animator.SetTrigger("Jump");
        }
        var target = Vector2.MoveTowards(chainik.position, player.position, speed * Time.fixedDeltaTime);
        chainik.MovePosition(target);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
