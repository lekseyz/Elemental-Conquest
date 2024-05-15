using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

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
        Destroy(gameObject, 0.4f); // ”ничтожаем объект босса
    }

    private void OnDestroy()
    {
        if (isDead)
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}