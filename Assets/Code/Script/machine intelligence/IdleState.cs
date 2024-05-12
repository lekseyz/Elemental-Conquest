using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 0; // ��������� ��������
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler.PlayerInRange())
        {
            animator.SetTrigger("Run"); // ������� � ��������� ����, ���� ����� � ���� ���������
        }
    }
}
