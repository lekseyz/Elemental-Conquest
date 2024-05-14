using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private bool hasDealtDamage = false; // Флаг для предотвращения многократного нанесения урона
    private float attackDuration = 1.0f; // Минимальное время в состоянии атаки
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StartAttack(); // Запуск атаки
            hasDealtDamage = false; // Сбрасываем флаг урона
        }
        startTime = Time.time; // Запоминаем время входа в состояние
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            // Синхронизируем нанесение урона с анимацией
            if (stateInfo.normalizedTime >= 0.5f && !hasDealtDamage)
            {
                patroler.DealDamage(); // Наносим урон
                hasDealtDamage = true; // Устанавливаем флаг урона
            }

            if (Time.time - startTime < attackDuration) return; // Ждем, пока не пройдет минимальное время

            // Проверяем, если игрок не в зоне атаки, переходим в другое состояние
            if (distance > patroler.attackDistance)
            {
                if (distance <= patroler.detectionDistance)
                {
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                    {
                        animator.SetTrigger("Jump"); // Переход в состояние прыжка
                    }
                }
                else
                {
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    {
                        animator.SetTrigger("Idle"); // Переход в состояние покоя
                    }
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StopAttack(); // Остановка атаки при выходе из состояния
        }
    }
}
