using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Torch : Interactable
{
    [SerializeField] private WallMove movement;
    public AudioSource torchSound;
    public Animator torchAnimator;
    public Transform soundObject;
    public float maxDistance = 10f;

    private void Awake()
    {
        // Check for necessary components and log errors if not assigned
        if (torchSound == null)
        {
            Debug.LogError("torchSound is not assigned in the Inspector!");
        }

        if (torchAnimator == null)
        {
            Debug.LogError("torchAnimator is not assigned in the Inspector!");
        }

        if (soundObject == null)
        {
            Debug.LogError("soundObject is not assigned in the Inspector!");
        }

        if (movement == null)
        {
            Debug.LogError("movement is not assigned in the Inspector!");
        }
    }

    override public void applyFireBall()
    {
        if (torchAnimator != null)
        {
            torchAnimator.SetBool("isActive", true);
        }
        else
        {
            Debug.LogError("torchAnimator is not assigned!");
        }

        if (movement != null)
        {
            movement.openWall();
        }
        else
        {
            Debug.LogError("movement is not assigned!");
        }

        if (torchSound != null)
        {
            torchSound.Play();
        }
        else
        {
            Debug.LogError("torchSound is not assigned!");
        }
    }

    private void Update()
    {
        if (soundObject != null && torchSound != null)
        {
            float distance = Vector2.Distance(transform.position, soundObject.position);
            float volume = 0.8f - Mathf.Clamp01(distance / maxDistance);
            torchSound.volume = volume;

            Debug.Log($"Distance: {distance}, Volume: {volume}");
        }
        else
        {
            if (soundObject == null)
            {
                Debug.LogError("soundObject is not assigned!");
            }

            if (torchSound == null)
            {
                Debug.LogError("torchSound is not assigned!");
            }
        }
    }

    override public void applyWind(Vector2 dir)
    {
        if (torchAnimator != null)
        {
            torchAnimator.SetBool("isActive", false);
        }
        else
        {
            Debug.LogError("torchAnimator is not assigned!");
        }

        if (torchSound != null)
        {
            torchSound.Stop();
        }
        else
        {
            Debug.LogError("torchSound is not assigned!");
        }

        if (movement != null)
        {
            movement.closeWall();
        }
        else
        {
            Debug.LogError("movement is not assigned!");
        }
    }

    public override void applyStone()
    {
    }
}
