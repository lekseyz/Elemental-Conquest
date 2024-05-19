using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Interactable
{
    private PatrolerKnight patroler;
    public override void applyFireBall()
    {
        patroler.takeDamage(25);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
