using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class IceShield : BasicSpell
{
    float lastTimeActivation = -1f;
    float activeTime = 5f;
    float cooldownTime = 1.5f;

    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        if (Time.time - lastTimeActivation < cooldownTime) return;

        lastTimeActivation = Time.time;
        Destructible dest = parent.GetComponentInParent<Destructible>();
        dest.isShielded = true;
        disable(dest);
    }

    private async Task disable(Destructible dest)
    {
        await Task.Delay(TimeSpan.FromSeconds(activeTime));
        dest.isShielded = false;        
    }
}
