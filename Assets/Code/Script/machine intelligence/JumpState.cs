using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    // Переопределяем метод OnStateEnter для обработки события входа в состояние
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            // Заменим вызов CanJump на вызов метода Jump, так как CanJump не определен
            patroler.Jump(); // Вызываем метод Jump
        }
        else
        {
            Debug.LogWarning("Patroler component not found.");
        }
    }
}
