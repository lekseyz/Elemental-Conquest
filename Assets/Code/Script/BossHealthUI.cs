using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public Boss boss; // Ссылка на объект класса Boss
    public Image healthFillImage; // Ссылка на изображение, отображающее заполнение полосы здоровья
    public GameObject text; // Ссылка на объект текста, который отображает информацию о здоровье босса

    void Start()
    {
        UpdateHealthUI(); // Обновляем UI здоровья при запуске сцены
    }

    void Update()
    {
        UpdateHealthUI(); // Обновляем UI здоровья каждый кадр

        // Проверяем, если здоровье босса меньше или равно нулю, то отключаем панель здоровья
        if (boss.CurrentHealth <= 0)
        {
            gameObject.SetActive(false); // Отключаем панель здоровья
            text.SetActive(false); // Отключаем текст с информацией о здоровье босса
        }
    }

    // Метод для обновления UI здоровья босса
    void UpdateHealthUI()
    {
        // Вычисляем процент здоровья босса
        float healthPercentage = boss.CurrentHealth / boss.maxHealth;

        // Устанавливаем заполнение изображения здоровья в соответствии с процентом здоровья босса
        healthFillImage.fillAmount = healthPercentage;
    }
}
