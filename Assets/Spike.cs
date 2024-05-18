using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool isActive = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive) return;

        var dest = collision.GetComponent<Destructible>();
        dest?.ApplyDamage(200);
    }
}
