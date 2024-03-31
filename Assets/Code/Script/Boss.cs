using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье босса
    public float currentHealth; // Текущее здоровье босса

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье равным максимальному при запуске
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Уменьшаем здоровье босса на значение damageAmount

        if (currentHealth <= 0)
        {
            Die(); // Если здоровье босса меньше или равно нулю, вызываем метод Die()
        }

        // Выводим текущее здоровье босса в консоль
        Debug.Log("Здоровье босса: " + currentHealth);
    }

    void Die()
    {
        // Действия, которые выполняются при смерти босса (например, анимация смерти, удаление объекта и т. д.)
        Debug.Log("Boss уничтожен!");
        Destroy(gameObject); // Уничтожаем объект босса
    }
}
