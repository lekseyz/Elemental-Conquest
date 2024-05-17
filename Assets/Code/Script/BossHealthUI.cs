using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public Boss boss; // ������ �� ������ ������ Boss
    public Image healthFillImage; // ������ �� �����������, ������������ ���������� ������ ��������
    public GameObject text; // ������ �� ������ ������, ������� ���������� ���������� � �������� �����

    void Start()
    {
        UpdateHealthUI(); // ��������� UI �������� ��� ������� �����
    }

    void Update()
    {
        UpdateHealthUI(); // ��������� UI �������� ������ ����

        // ���������, ���� �������� ����� ������ ��� ����� ����, �� ��������� ������ ��������
        if (boss.CurrentHealth <= 0)
        {
            gameObject.SetActive(false); // ��������� ������ ��������
            text.SetActive(false); // ��������� ����� � ����������� � �������� �����
        }
    }

    // ����� ��� ���������� UI �������� �����
    void UpdateHealthUI()
    {
        // ��������� ������� �������� �����
        float healthPercentage = boss.CurrentHealth / boss.maxHealth;

        // ������������� ���������� ����������� �������� � ������������ � ��������� �������� �����
        healthFillImage.fillAmount = healthPercentage;
    }
}
