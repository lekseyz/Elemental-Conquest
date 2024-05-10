using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    // �������������� ����� OnStateEnter ��� ��������� ������� ����� � ���������
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Patroler patroler = animator.GetComponent<Patroler>();
        if (patroler != null)
        {
            // ������� ����� CanJump �� ����� ������ Jump, ��� ��� CanJump �� ���������
            patroler.Jump(); // �������� ����� Jump
        }
        else
        {
            Debug.LogWarning("Patroler component not found.");
        }
    }
}
