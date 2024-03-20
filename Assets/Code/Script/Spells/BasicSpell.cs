using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : ScriptableObject
{
    float lastTimeActivation;
    float activeTime;
    float cooldownTime;

    public virtual void activate(GameObject parent, Vector3 dir, float angle) { }
}
