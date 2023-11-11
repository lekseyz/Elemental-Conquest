using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : BasicSpell
{
    public GameObject fireBall;

    public override void activate(GameObject parent)
    {
        fireBall.transform.position = parent.transform.position;
        fireBall.transform.rotation = parent.transform.rotation;
        Instantiate(fireBall);
    }
}
