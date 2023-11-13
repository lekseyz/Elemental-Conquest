using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BasicSpell
{
    public override void activate(GameObject parent, Vector3 dir)
    {
        parent.GetComponent<Walk>().Dash(true);
    }
   
}
