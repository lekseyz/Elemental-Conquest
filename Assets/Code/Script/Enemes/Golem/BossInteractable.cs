using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteractable : Interactable
{
    Boss boss;
    private void Start()
    {
        boss = GetComponent<Boss>();
    }
    
    public override void applyFireBall()
    {
        boss.TakeDamage(10);
    }

    public override void applyStone()
    {
        boss.TakeDamage(25);
    }

    public override void applyWind(Vector2 dir)
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((new Vector2(dir.x, dir.y) * 1500000), ForceMode2D.Force);
    }
}
