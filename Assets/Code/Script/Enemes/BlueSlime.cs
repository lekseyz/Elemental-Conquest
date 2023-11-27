using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlime : Interactable
{
    [SerializeField] SliderController controller;

    private void Start()
    {
        controller = GetComponentInChildren<SliderController>();
    }

    float HP = 100;
    float currentHP = 100;

    private void Update()
    {
        if (currentHP < 0) {
            Destroy(gameObject);
        }
    }

    override public void applyFireBall()
    {
        currentHP -= 20;
        controller.UpdateSliderVal(currentHP, HP);
    }

    override public void applyWind(Vector2 dir)
    {

    }
}
