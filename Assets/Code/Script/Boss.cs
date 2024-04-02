using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� �����
    public float currentHealth; // ������� �������� �����
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();  
        currentHealth = maxHealth; // ������������� ������� �������� ������ ������������� ��� �������
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // ��������� �������� ����� �� �������� damageAmount

        if (currentHealth <= 0)
        {
            Die(); // ���� �������� ����� ������ ��� ����� ����, �������� ����� Die()
        }

        // ������� ������� �������� ����� � �������
        Debug.Log("�������� �����: " + currentHealth);
    }

    void Die()
    {
        // ��������, ������� ����������� ��� ������ ����� (��������, �������� ������, �������� ������� � �. �.)
        Debug.Log("Boss ���������!");
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.4f); // ���������� ������ �����
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Gameover");
    }
}
