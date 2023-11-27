using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : BasicSpell
{
    override public void activate(GameObject parent, Vector3 dir, float angle) {
        parent.GetComponent<ParticleSystem>().Emit(200);
    }
}
