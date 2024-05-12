using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.Jump(); // ������ ������
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (!patroler.PlayerInRange())
        {
            animator.SetTrigger("Run"); // ������� � ��������� ����, ���� ����� ��� ���� ���������
        }
    }
}
