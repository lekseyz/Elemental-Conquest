using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBall : BasicSpell
{
    public GameObject fireBall;

    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        fireBall.transform.position = parent.transform.position;
        fireBall.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle);
        fireBall.GetComponent<FireBallScript>().dir = dir;
        Instantiate(fireBall);
    }

}
