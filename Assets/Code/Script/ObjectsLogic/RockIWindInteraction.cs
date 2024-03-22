using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : Interactable
{
    
    public override void applyFireBall()
    {
    }
    public override void applyWind(Vector2 dir)
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((new Vector2(dir.x, dir.y) * 100000), ForceMode2D.Force);
    }
    public override void applyStone()
    {
    }
}
