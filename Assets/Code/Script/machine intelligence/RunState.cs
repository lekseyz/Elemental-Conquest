using UnityEngine;

public class RunState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 3; // ��������� �������� ��� ����
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            if (patroler.PlayerInRange())
            {
                patroler.MoveTowardsPlayer();  // ���� � ������, ���� �� � �������� ��������
            }
            else
            {
                patroler.MoveToNextPoint();  // ����� ��������� � ��������� �����
            }

            // ��������, ������ �� ��� ����� � ��������� �� ����� ��� ���� �����������
            if (!patroler.PlayerInRange() && patroler.HasReachedCurrentPoint() && patroler.CurrentPointIndex != 0)
            {
                animator.SetBool("Idle", true);  // ���� ����� ���������� � ����� ������, ������� � Idle
            }
            else
            {
                animator.SetBool("Idle", false);  // ���� �� �������� ������ � �� ���������� ������ �����, ���������� ��������
            }
        }
    }

}
