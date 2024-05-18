using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeOut : StateMachineBehaviour
{
    Spike spike;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spike = animator.GetComponentInParent<Spike>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!spike.isActive)
            animator.Play("SpikeIn");
    }
}
