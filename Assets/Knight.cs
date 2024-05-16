using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Interactable
{
    private PatrolerKnight patroler;
    public override void applyFireBall()
    {
        throw new System.NotImplementedException();
    }

    public override void applyStone()
    {
        throw new System.NotImplementedException();
    }

    public override void applyWind(Vector2 dir)
    {
        throw new System.NotImplementedException();
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
