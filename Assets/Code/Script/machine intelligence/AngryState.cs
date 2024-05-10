using UnityEngine;

public class AngryState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.MoveTowardsPlayer();  // Обеспечение доступа к методу
        }
    }
}
