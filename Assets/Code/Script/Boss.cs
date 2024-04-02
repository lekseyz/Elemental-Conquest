using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье босса
    public float currentHealth; // Текущее здоровье босса
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();  
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
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.4f); // Уничтожаем объект босса
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Gameover");
    }
}
