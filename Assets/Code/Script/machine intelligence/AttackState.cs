using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    // Метод OnStateEnter вызывается при входе в состояние для выполнения начальных действий
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StartAttack(); // Запускаем метод StartAttack
        }
        else
        {
            Debug.LogWarning("Компонент Patroler не найден.");
        }
    }

    // Метод OnStateUpdate вызывается каждый кадр в состоянии для выполнения действий в процессе
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (!patroler.PlayerInAttackRange())
        {
            animator.SetTrigger("Run"); // Если игрок вне зоны атаки, переходим в состояние Run
        }
    }

    // Метод OnStateExit вызывается при выходе из состояния для завершения текущего состояния
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StopAttack(); // Останавливаем метод StopAttack
        }
    }
}
