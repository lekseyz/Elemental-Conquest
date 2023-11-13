using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : BasicSpell
{
    public GameObject fireBall;

    public override void activate(GameObject parent, Vector3 dir)
    {
        fireBall.transform.position = parent.transform.position;
        fireBall.GetComponent<FireBallScript>().dir = dir;
        Instantiate(fireBall);
    }
}
