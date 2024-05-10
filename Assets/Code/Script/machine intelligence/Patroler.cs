using UnityEngine;
using System.Collections.Generic;

public class Patroler : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float speed = 3f;
    public float attackDistance = 2f;
    public float detectionDistance = 5f;
    public List<Transform> points;
    [SerializeField] private int currentPointIndex;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool enemyDie = false;
    public bool EnemyDie => enemyDie;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player == null)
            {
                Debug.LogError("Player object not found. Please assign a Player GameObject with the 'Player' tag.");
                return;
            }
        }
        currentPointIndex = Random.Range(0, points.Count);
    }

    public int CurrentPointIndex { get { return currentPointIndex; } }
    public bool HasReachedCurrentPoint()
    {
        if (points != null && points.Count > 0 && currentPointIndex < points.Count)
        {
            return Vector3.Distance(transform.position, points[currentPointIndex].position) < 1f;
        }
        return false;
    }

    public bool IsNextPointAvailable()
    {
        return currentPointIndex + 1 < points.Count; // Проверяем, есть ли следующая точка
    }

    public void SetNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % points.Count; // Перемещаем индекс к следующей точке
    }


    void Update()
    {
        if (enemyDie)
        {
            animator.SetBool("Die", true);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log($"Distance to player: {distance}");  // Debugging distance

        if (distance <= attackDistance)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Idle", false);
        }
        else if (distance <= detectionDistance)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
    }
    public void AdvanceToNextPoint()
    {
        if (points != null && points.Count > 0)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Count;  // Циклический переход к следующей точке
        }
    }

    public bool IsLastPoint()
    {
        // Проверка, является ли текущая точка последней в списке
        return currentPointIndex == points.Count - 1;
    }


    public void MoveTowardsPlayer()
    {
        if (!enemyDie && player != null && Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void MoveToNextPoint()
    {
        if (points.Count > 0 && points[currentPointIndex] != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 1f)
            {
                currentPointIndex = (currentPointIndex + 1) % points.Count;
            }
        }
    }

    public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) < detectionDistance;
    }

    public bool PlayerInAttackRange()
    {
        return !enemyDie && player != null && Vector3.Distance(transform.position, player.position) <= attackDistance;
    }

    public void StartAttack()
    {
        Debug.Log("Attack started");
    }

    public void StopAttack()
    {
        Debug.Log("Attack stopped");
    }

    public void Jump()
    {
        Debug.Log("Jumped");
        isJumping = true;
    }

    public void Die()
    {
        Debug.Log("Died");
        enemyDie = true;
    }

    public void SetEnemyDie(bool value)
    {
        enemyDie = value;  // Установка значения для enemyDie
        if (enemyDie)
        {
            animator.SetBool("Die", true);  // Установка анимации смерти
        }
    }
}
