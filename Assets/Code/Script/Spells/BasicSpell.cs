using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : ScriptableObject
{
    public float activeTime;
    public float cooldownTime;

    public virtual void activate(GameObject parent, Vector3 dir) { }
}
