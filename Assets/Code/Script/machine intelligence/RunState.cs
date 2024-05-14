using UnityEngine;

public class RunState : StateMachineBehaviour
{
    private float runDuration = 1.0f; // Минимальное время в состоянии бега
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 5; // Установка скорости для бега
        }
        startTime = Time.time; // Запоминаем время входа в состояние
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            if (Time.time - startTime < runDuration) return; // Ждем, пока не пройдет минимальное время

            if (distance > patroler.detectionDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.SetTrigger("Idle"); // Переход в состояние покоя, если игрок вне зоны видимости
                }
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
