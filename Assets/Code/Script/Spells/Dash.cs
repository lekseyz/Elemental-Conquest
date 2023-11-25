using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BasicSpell
{
    GameObject player;
    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        GameObject.Find("MainHero").GetComponent<Walk>().Dash(true);
    }
   
}
