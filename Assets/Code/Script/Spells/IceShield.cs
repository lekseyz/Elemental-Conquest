using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShield : BasicSpell
{
    float lastTimeActivation = -1f;
    float activeTime = 20f;
    float cooldownTime = 1.5f;

    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        if (Time.time - lastTimeActivation < cooldownTime) return;

        lastTimeActivation = Time.time;
        Destructible dest = parent.GetComponentInParent<Destructible>();
        dest.isShielded = true;
        disableShield(dest);

        dest.isShielded = false;
    }

    private IEnumerator disableShield(Destructible dest)
    {
        yield return new WaitForSeconds(activeTime);
    }
}
