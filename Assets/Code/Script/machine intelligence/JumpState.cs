using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    private float jumpDuration = 1.0f; // Минимальное время в состоянии прыжка
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.Jump(); // Запуск прыжка
            patroler.speed = 4.5f; // Увеличение скорости
        }
        startTime = Time.time; // Запоминаем время входа в состояние
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            patroler.MoveTowardsPlayer(); // Движение к игроку во время прыжка

            if (Time.time - startTime < jumpDuration) return; // Ждем, пока не пройдет минимальное время

            if (distance <= patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    animator.SetTrigger("Attack"); // Переход в состояние атаки
                }
            }
            else if (distance > patroler.detectionDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.SetTrigger("Idle"); // Переход в состояние покоя, если игрок вне зоны видимости
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 1.5f; // Восстановление скорости
            patroler.isJumping = false; // Сброс флага прыжка
        }
    }
}
