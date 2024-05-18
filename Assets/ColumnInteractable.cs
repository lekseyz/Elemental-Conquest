using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInteractable : Interactable
{
    Column _column;
    public override void applyFireBall()
    {
        _column.takeDamage(25);
    }

    public override void applyWind(Vector2 dir)
    {

    }

    public override void applyStone()
    {
        _column.takeDamage(25);
    }
    public void Start()
    {
        _column = GetComponent<Column>();
    }
}
