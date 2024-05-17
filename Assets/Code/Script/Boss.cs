using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth; // ������� ���� currentHealth
    Animator animator;
    private bool isDead = false;

    // ���� ����� ������ �����
    public AudioSource deathSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // ������� ���� currentHealth � ��������� Unity
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

        // ���������� ������ ����� ����� 5 ������
        Invoke("DestroyBoss", 2.5f);
    }

    // ����� ��� ����������� ������� �����
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
