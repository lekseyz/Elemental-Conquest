using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : BasicSpell
{
    override public void activate(GameObject parent, Vector3 dir, float angle)
    {
        parent.GetComponent<ParticleSystem>().Emit(200);
        //var cols = parent.GetComponent<HitBox>();
        var cols = parent.GetComponent<HitBox>().GetCols();
        foreach(var col in cols)
        {
            var newDir = col.transform.position - parent.gameObject.transform.position;
            newDir = newDir.normalized;
            col.gameObject.GetComponent<Interactable>().applyWind(new Vector2(newDir.x, newDir.y));
        }
    }
}
