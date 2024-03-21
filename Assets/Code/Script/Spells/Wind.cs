using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : BasicSpell
{
    override public void activate(GameObject parent, Vector3 dir, float angle)
    {
        parent.GetComponent<ParticleSystem>().Emit(200);
        var cols = parent.GetComponent<HitBox>();
        foreach(var col in cols.colliders)
        {
            col.gameObject.GetComponent<Interactable>().applyWind(new Vector2(dir.x, dir.y));
        }
    }
}
