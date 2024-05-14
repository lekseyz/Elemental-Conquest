using UnityEngine;

public class DieState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler == null) throw new System.Exception();

        patroler.setSpeed(Patroler.SpeedStates.Stay);
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
