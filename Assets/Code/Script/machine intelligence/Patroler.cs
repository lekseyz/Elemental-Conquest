using UnityEngine;

public class Patroler : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float speed = 3f;
    public float attackDistance = 2f;
    public float detectionDistance = 5f;
    public bool isDead = false;

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned.");
            return;
        }

        if (isDead)
        {
            return; // Не делать ничего, если враг мёртв
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < detectionDistance)
        {
            if (distance < attackDistance)
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Run", true);
            }
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }

    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void StartAttack()
    {
        Debug.Log("Start Attack");
    }

    public void StopAttack()
    {
        Debug.Log("Stop Attack");
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

    public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) < detectionDistance;
    }

    public bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackDistance;
    }
}
