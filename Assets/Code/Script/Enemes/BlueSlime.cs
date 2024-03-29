using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : Interactable
{
    [SerializeField] SliderController controller;
    private float timerDuration = 1.5f;
    private bool isTimerRunning;
    public Animator animator;

private void Start()
    {
        controller = GetComponentInChildren<SliderController>();
        isTimerRunning = false;
    }

    float HP = 100;
    float currentHP = 100;

    private void Update()
    {
        if (currentHP <= 0)
        {
            Patroler.enemyDie = true;
            animator.SetBool("Die", Patroler.enemyDie);
            StartCoroutine(DisappearTimer());
        }
    }

    public override void applyFireBall()
    {
        currentHP -= 25;
        controller.UpdateSliderVal(currentHP, HP);
    }

    public override void applyWind(Vector2 dir)
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((new Vector2(dir.x, dir.y) * 1500), ForceMode2D.Force);
    }
    public override void applyStone()
    {
        currentHP -=50;
        controller.UpdateSliderVal(currentHP, HP);
    }
    IEnumerator DisappearTimer()
    {
        isTimerRunning = true;
        yield return new WaitForSeconds(timerDuration);
        Destroy(gameObject);
    }
}