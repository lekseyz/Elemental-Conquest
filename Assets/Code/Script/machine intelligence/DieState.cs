using UnityEngine;

public class DieState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.Die(); // Вызов метода Die при входе в состояние смерти
        }
    }
}
