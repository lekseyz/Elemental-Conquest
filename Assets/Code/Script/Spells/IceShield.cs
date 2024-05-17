using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class IceShield : BasicSpell
{
    float lastTimeActivation = -1f;
    //float activeTime = 0.5f;
    float cooldownTime = 1.5f;
    Animator animator;

    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        animator = parent.GetComponentInParent<Animator>();
        if (Time.time - lastTimeActivation < cooldownTime) return;

        lastTimeActivation = Time.time;
        //Destructible dest = parent.GetComponentInParent<Destructible>();
        animator.SetTrigger("Shield");
        //disable(dest);
    }

    //private async Task disable(Destructible dest)
    //{
    //    await Task.Delay(TimeSpan.FromSeconds(activeTime));
    //    dest.isShielded = false;
    //}
}
