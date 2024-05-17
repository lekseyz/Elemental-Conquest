using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInteractable : Interactable
{
    Boss boss;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        boss = GetComponent<Boss>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public override void applyFireBall()
    {
        boss.TakeDamage(10);
        spriteRenderer.color = Color.red;
        StartCoroutine(Countdoun());
    }
    IEnumerator Countdoun()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public override void applyStone()
    {
        boss.TakeDamage(25);
        spriteRenderer.color = Color.red;
        StartCoroutine(Countdoun());
    }

    public override void applyWind(Vector2 dir)
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((new Vector2(dir.x, dir.y) * 1500000), ForceMode2D.Force);
    }
}
