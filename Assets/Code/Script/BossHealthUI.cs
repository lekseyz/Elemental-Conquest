using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public Boss boss;
    public Image healthFillImage;
    public GameObject text;

    void Start()
    {
        UpdateHealthUI();
    }

    void Update()
    {
        UpdateHealthUI();

        // ���������, ���� �������� ����� ������ ��� ����� ����, �� ��������� ������ ��������
        if (boss.currentHealth <= 0)
        {
            gameObject.SetActive(false);
            text.SetActive(false);
        }
    }

    void UpdateHealthUI()
    {
        float healthPercentage = boss.currentHealth / boss.maxHealth;
        healthFillImage.fillAmount = healthPercentage;
    }
}
