using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private float idleTime = 1.0f; // Минимальное время в состоянии покоя
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 1; // Медленное движение в состоянии покоя
        }
        startTime = Time.time; // Запоминаем время входа в состояние
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            if (Time.time - startTime < idleTime) return; // Ждем, пока не пройдет минимальное время

            if (distance > patroler.detectionDistance)
            {
                patroler.MoveToNextPoint(); // Продолжение движения по точкам
            }
            else if (distance <= patroler.detectionDistance && distance > patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    animator.SetTrigger("Jump"); // Переход в состояние прыжка
                }
            }
            else if (distance <= patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    animator.SetTrigger("Attack"); // Переход в состояние атаки
                }
            }
        }
    }
}
