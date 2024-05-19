using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainikInteractable : Interactable
{
    ChainikController controller;
    Rigidbody2D rigidbody;

    public override void applyFireBall()
    {
        controller.TakeDamage(50); 
    }

    public override void applyStone()
    {
        controller.TakeDamage(100); 
    }

    public override void applyWind(Vector2 dir)
    {
        rigidbody.AddForce(dir, ForceMode2D.Impulse); 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ChainikController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
