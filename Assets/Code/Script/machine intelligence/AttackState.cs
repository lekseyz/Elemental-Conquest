using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private bool hasDealtDamage = false; // ���� ��� �������������� ������������� ��������� �����
    private float attackDuration = 1.0f; // ����������� ����� � ��������� �����
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.StartAttack(); // ������ �����
            hasDealtDamage = false; // ���������� ���� �����
        }
        startTime = Time.time; // ���������� ����� ����� � ���������
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            // �������������� ��������� ����� � ���������
            if (stateInfo.normalizedTime >= 0.5f && !hasDealtDamage)
            {
                patroler.DealDamage(); // ������� ����
                hasDealtDamage = true; // ������������� ���� �����
            }

            if (Time.time - startTime < attackDuration) return; // ����, ���� �� ������� ����������� �����

            // ���������, ���� ����� �� � ���� �����, ��������� � ������ ���������
            if (distance > patroler.attackDistance)
            {
                if (distance <= patroler.detectionDistance)
                {
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                    {
                        animator.SetTrigger("Jump"); // ������� � ��������� ������
                    }
                }
                else
                {
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                    {
                        animator.SetTrigger("Idle"); // ������� � ��������� �����
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
            patroler.StopAttack(); // ��������� ����� ��� ������ �� ���������
        }
    }
}
