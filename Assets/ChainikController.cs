using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainikController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealt = 100;

    private Animator animator;

    public void takeDamage(int damage)
    {
        currentHealt -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealt <= 0)
        {
            animator.SetTrigger("Dead");
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var destructible = collision.gameObject.GetComponent<Destructible>();
            destructible.ApplyDamage(10);
        }
    }
}
