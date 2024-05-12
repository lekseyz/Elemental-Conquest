using UnityEngine;

public class RunState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 5; // ��������� �������� ��� ����
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            if (patroler.PlayerInRange())
            {
                patroler.MoveTowardsPlayer(); // �������� � ������
            }
            else
            {
                animator.SetTrigger("Idle"); // ������� � ��������� �����, ���� ����� ��� ���� ���������
            }
        }
    }
}
