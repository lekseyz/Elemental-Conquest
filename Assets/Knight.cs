using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Interactable
{
    private PatrolerKnight patroler;
    private SpriteRenderer spriteRenderer;
    public override void applyFireBall()
    {
        patroler.takeDamage(25);
        spriteRenderer.color = Color.red;
        StartCoroutine(redTime(spriteRenderer));
    }
    IEnumerator redTime(SpriteRenderer sp)
    {
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
    }
    public override void applyStone()
    {
        patroler.takeDamage(0);
    
    }   

    public override void applyWind(Vector2 dir)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        patroler = gameObject.GetComponent<PatrolerKnight>();
        spriteRenderer = patroler.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
