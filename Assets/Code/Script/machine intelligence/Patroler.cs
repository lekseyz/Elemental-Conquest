using UnityEngine;
using System.Collections.Generic;

public class Patroler : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float speed = 3f;
    public float attackDistance = 2f;
    public float detectionDistance = 5f;
    public bool isDead = false;
    public List<Transform> points = new List<Transform>();
    private int currentPointIndex;
    private Destructible playerDestructible;

    public bool isAttacking = false; // флаг атаки
    public bool isJumping = false; // флаг прыжка

    private float attackCooldown = 1.5f; // Задержка перед следующей атакой
    private float jumpCooldown = 1.0f; // Задержка перед следующим прыжком
    private float lastAttackTime;
    private float lastJumpTime;

    void Start()
    {
        if (points == null || points.Count == 0)
        {
            Debug.LogError("Points list is not assigned or empty.");
            return;
        }

        currentPointIndex = Random.Range(0, points.Count);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject == null)
        {
            Debug.LogError("Player object with tag 'Player' is not found.");
            return;
        }

        player = playerObject.transform;

        playerDestructible = playerObject.GetComponent<Destructible>();
        if (playerDestructible == null)
        {
            Debug.LogError("Player Destructible component is not found on object: " + playerObject.name);
            return;
        }

        lastAttackTime = -attackCooldown;
        lastJumpTime = -jumpCooldown;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned.");
            return;
        }

        if (isDead)
        {
            animator.SetTrigger("Die");
            return; // Не делать ничего, если враг мёртв
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > detectionDistance)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetTrigger("Idle");
                isAttacking = false; // сброс флага атаки
                isJumping = false; // сброс флага прыжка
            }

            MoveToNextPoint(); // Патрулирование
        }
        else if (distance <= detectionDistance && distance > attackDistance)
        {
            if (!isJumping && Time.time - lastJumpTime > jumpCooldown)
            {
                animator.SetTrigger("Jump");
                isJumping = true;
                lastJumpTime = Time.time;
            }
        }
        else if (distance <= attackDistance)
        {
            if (!isAttacking && Time.time - lastAttackTime > attackCooldown)
            {
                animator.SetTrigger("Attack");
                isAttacking = true;
                isJumping = false; // сброс флага прыжка
                lastAttackTime = Time.time;
            }
        }
    }

    public void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void MoveToNextPoint()
    {
        if (points.Count > 0 && points[currentPointIndex] != null)
        {
            if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 1f)
            {
                currentPointIndex = Random.Range(0, points.Count);
            }

            transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
        }
    }

    public void StartAttack()
    {
        Debug.Log("Start Attack");
    }

    public void StopAttack()
    {
        Debug.Log("Stop Attack");
        isAttacking = false; // сброс флага атаки
    }

    public void Jump()
    {
        Debug.Log("Patroler is jumping");
    }

    public void SetEnemyDie()
    {
        isDead = true;
        // Дополнительные действия при смерти врага
    }

    public void Die()
    {
        Debug.Log("Enemy is dead");
        // Дополнительные действия при смерти врага
    }

    public void DealDamage()
    {
        if (playerDestructible != null)
        {
            playerDestructible.ApplyDamage(1); // Наносим урон
        }
    }

    public bool PlayerInRange()
    {
        return player != null && Vector3.Distance(transform.position, player.position) < detectionDistance;
    }

    public bool PlayerInAttackRange()
    {
        return player != null && Vector3.Distance(transform.position, player.position) < attackDistance;
    }
}
