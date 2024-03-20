using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShield : BasicSpell
{
    float lastTimeActivation = -1f;
    float activeTime = 0.5f;
    float cooldownTime = 1.5f;

    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        if (Time.time - lastTimeActivation < cooldownTime) return;

        lastTimeActivation = Time.time;
        var dest = parent.GetComponent<Destructible>();
        dest.isShielded = true;
        disableShield(dest);
    }

    private IEnumerator disableShield(Destructible dest)
    {
        yield return new WaitForSeconds(activeTime);
        dest.isShielded = false;
    }
}
