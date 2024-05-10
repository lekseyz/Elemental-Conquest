using UnityEngine;

public class RunState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 3; // ”становка скорости дл€ бега
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            if (patroler.PlayerInRange())
            {
                patroler.MoveTowardsPlayer();  // »дти к игроку, если он в пределах детекции
            }
            else
            {
                patroler.MoveToNextPoint();  // »наче двигатьс€ к следующей точке
            }

            // ѕроверка, достиг ли моб точки и находитс€ ли игрок вне зоны обнаружени€
            if (!patroler.PlayerInRange() && patroler.HasReachedCurrentPoint() && patroler.CurrentPointIndex != 0)
            {
                animator.SetBool("Idle", true);  // ≈сли точка достигнута и игрок далеко, переход в Idle
            }
            else
            {
                animator.SetBool("Idle", false);  // ≈сли не встретил игрока и не достигнута перва€ точка, продолжать движение
            }
        }
    }

}
