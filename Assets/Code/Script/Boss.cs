using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();  
        currentHealth = maxHealth; 
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; 

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.4f); // ”ничтожаем объект босса
        SceneManager.LoadScene("WinMenu");
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }
}
