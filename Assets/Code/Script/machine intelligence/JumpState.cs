using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.Jump(); // Запуск прыжка
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (!patroler.PlayerInRange())
        {
            animator.SetTrigger("Run"); // Переход в состояние бега, если игрок вне зоны видимости
        }
    }
}
