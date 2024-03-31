using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� �����
    public float currentHealth; // ������� �������� �����

    void Start()
    {
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
        Destroy(gameObject); // ���������� ������ �����
    }
}
