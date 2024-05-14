using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : Interactable
{
    [SerializeField] SliderController controller;
    public Animator animator;

    private void Start()
    {
        controller = GetComponentInChildren<SliderController>();
    }

    float HP = 100;
    private float currentHP = 100;

    // Свойство для получения текущего здоровья
    public float CurrentHP
    {
        get { return currentHP; }
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            animator.SetTrigger("Die");
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
        currentHP -= 50;
        controller.UpdateSliderVal(currentHP, HP);
    }
}
