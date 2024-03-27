using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Torch : Interactable
{
    public AudioSource torchSound;
    public Animator torchAnimator;
    public Transform soundObject;
    public float maxDistance = 10f;
    override public void applyFireBall()
    {
        torchAnimator.SetBool("isActive", true);
        torchSound.pitch = Random.Range(0.8f, 1f);
        torchSound.Play();
    }
    

    private void Update()
    {
        torchSound.volume = 0.8f - Mathf.Clamp01(Vector2.Distance(transform.position, soundObject.position) / maxDistance);
    }

    override public void applyWind(Vector2 dir)
    {
        torchAnimator.SetBool("isActive", false);
        torchSound.Stop();
    }
    public override void applyStone()
    {
    }
}
