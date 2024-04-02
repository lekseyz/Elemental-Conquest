using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Patroler : MonoBehaviour
{
    private DamageZone dest;
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
        while(Time.time < 0.5) { }
        dest = GetComponent<DamageZone>();
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

            if (Vector2.Distance(transform.position, player.position) < findDistance || Vector2.Distance(transform.position, player.position) > 1f && Vector2.Distance(transform.position, player.position) < 3f)
            {
                angry = true;
                idle = false;
                attack = false;
            }

            if (Vector2.Distance(transform.position, player.position) < 1f)
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
                dest.setDistractible(playerDestructible);
            }
            if(attack == false)
            {
                dest.resetDestractible();
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

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(1);
        
    }


    void Jump()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 5f;
    }
}
