using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    // ����� OnStateEnter ���������� ��� ����� � ��������� ��� ���������� ��������� ��������
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StartAttack(); // ��������� ����� StartAttack
        }
        else
        {
            Debug.LogWarning("��������� Patroler �� ������.");
        }
    }

    // ����� OnStateUpdate ���������� ������ ���� � ��������� ��� ���������� �������� � ��������
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (!patroler.PlayerInAttackRange())
        {
            animator.SetTrigger("Run"); // ���� ����� ��� ���� �����, ��������� � ��������� Run
        }
    }

    // ����� OnStateExit ���������� ��� ������ �� ��������� ��� ���������� �������� ���������
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StopAttack(); // ������������� ����� StopAttack
        }
    }
}
