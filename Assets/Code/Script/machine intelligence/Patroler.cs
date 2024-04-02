using UnityEngine;
using System.Collections.Generic;

public class Patroler : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float findDistance;
    public List<Transform> points = new List<Transform>();
    public static bool enemyDie = false;
    public Animator animator;
    Transform player;
    int currentPointIndex;
    bool angry = false;
    bool attack = false;
    bool jump = false;
    bool idle = true;

    private Destructible playerDestructible;

    void Start()
    {
        currentPointIndex = Random.Range(0, points.Count);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Получаем компонент Destructible у игрока
        playerDestructible = player.GetComponent<Destructible>();
    }

    void Update()
    {
        UpdateAnimatorBooleans();
        Check();
    }

    void UpdateAnimatorBooleans()
    {
        animator.SetBool("Jump", jump);
        animator.SetBool("Attack", attack);
        animator.SetBool("Idle", idle);
    }

    void Check()
    {
        if (!Patroler.enemyDie)
        {
            if (!attack)
            {
                if (Vector2.Distance(transform.position, points[currentPointIndex].position) < 1 && Vector2.Distance(transform.position, player.position) > findDistance)
                {
                    currentPointIndex = Random.Range(0, points.Count);
                    idle = true;
                    jump = false;
                }

                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("wall"))
                    {
                        if (Vector2.Distance(transform.position, collider.transform.position) < 2f)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
                            return;
                        }
                    }
                }
            }

            if (Vector2.Distance(transform.position, player.position) < findDistance || Vector2.Distance(transform.position, player.position) > 0.5f && Vector2.Distance(transform.position, player.position) < 3f)
            {
                angry = true;
                idle = false;
                attack = false;
            }

            if (Vector2.Distance(transform.position, player.position) < 0.5f)
            {
                angry = false;
                attack = true;
                jump = false;
            }

            if (Vector2.Distance(transform.position, player.position) > 3f && Vector2.Distance(transform.position, player.position) < 7f)
            {
                angry = false;
                attack = false;
                jump = true;
            }

            if (angry == true)
            {
                Angry();
            }

            if (jump == true)
            {
                Jump();
            }

            if (idle == true)
            {
                Idle();
            }

            if (attack == true)
            {
                Attack();
            }
        }
        else
        {
            speed = 0;
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 4;
    }

    void Idle()
    {
        speed = 1f;
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex].position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if (playerDestructible != null && !playerDestructible.isShielded && Vector2.Distance(transform.position, player.position) < findDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            speed = 3f;

            // Проверяем, есть ли компонент Destructible у игрока, и вызываем ApplyDamage()
            if (playerDestructible != null)
            {
                playerDestructible.ApplyDamage(10); //  наносит урон
            }
        }
    }


    void Jump()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 5f;
    }
}
