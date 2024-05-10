using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            // Check if the player is in range for attack
            if (patroler.PlayerInRange())
            {
                // If player is in range, transition to Attack state
                animator.SetBool("Attack", true);
            }
            else
            {
                // Player is not in range, remain in Idle state
                animator.SetBool("Attack", false);
            }
        }
    }
}
