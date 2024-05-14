using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    private float jumpDuration = 1.0f; // ����������� ����� � ��������� ������
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.Jump(); // ������ ������
            patroler.speed = 4.5f; // ���������� ��������
        }
        startTime = Time.time; // ���������� ����� ����� � ���������
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            patroler.MoveTowardsPlayer(); // �������� � ������ �� ����� ������

            if (Time.time - startTime < jumpDuration) return; // ����, ���� �� ������� ����������� �����

            if (distance <= patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    animator.SetTrigger("Attack"); // ������� � ��������� �����
                }
            }
            else if (distance > patroler.detectionDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.SetTrigger("Idle"); // ������� � ��������� �����, ���� ����� ��� ���� ���������
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 1.5f; // �������������� ��������
            patroler.isJumping = false; // ����� ����� ������
        }
    }
}
