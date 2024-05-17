using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth; // Скрытое поле currentHealth
    Animator animator;
    private bool isDead = false;

    // Звук после смерти босса
    public AudioSource deathSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Скрытие поля currentHealth в редакторе Unity
    [HideInInspector]
    public float CurrentHealth { get { return currentHealth; } }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Death");

        if (deathSound != null && deathSound.enabled)
        {
            deathSound.Play();
        }

        // Уничтожаем объект босса через 5 секунд
        Invoke("DestroyBoss", 2.5f);
    }

    // Метод для уничтожения объекта босса
    void DestroyBoss()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        /*
        if (isDead)
        {
            SceneManager.LoadScene("WinMenu");
        }*/
    }
}
