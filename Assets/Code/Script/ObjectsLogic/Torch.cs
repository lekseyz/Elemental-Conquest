using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Torch : Interactable
{
    public Animator torchAnimator;
    override public void applyFireBall()
    {
        torchAnimator.SetBool("isActive", true);
    }

    override public void applyWind(Vector2 dir)
    {
        torchAnimator.SetBool("isActive", false);
    }
}
