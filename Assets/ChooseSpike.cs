using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpike : StateMachineBehaviour
{
    Spike spike;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spike = animator.GetComponentInParent<Spike>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spike.isActive)
            animator.Play("SpikeOut");
        else
            animator.Play("SpikeIn");
    }
}
