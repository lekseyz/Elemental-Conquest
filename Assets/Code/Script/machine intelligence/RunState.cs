using UnityEngine;

public class RunState : StateMachineBehaviour
{
    private float runDuration = 1.0f; // ����������� ����� � ��������� ����
    private float startTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            patroler.speed = 5; // ��������� �������� ��� ����
        }
        startTime = Time.time; // ���������� ����� ����� � ���������
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            float distance = Vector3.Distance(patroler.transform.position, patroler.player.position);

            if (Time.time - startTime < runDuration) return; // ����, ���� �� ������� ����������� �����

            if (distance > patroler.detectionDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                {
                    animator.SetTrigger("Idle"); // ������� � ��������� �����, ���� ����� ��� ���� ���������
                }
            }
            else if (distance <= patroler.detectionDistance && distance > patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    animator.SetTrigger("Jump"); // ������� � ��������� ������
                }
            }
            else if (distance <= patroler.attackDistance)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    animator.SetTrigger("Attack"); // ������� � ��������� �����
                }
            }
        }
    }
}
