using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightDamager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destructible destructible = collision.GetComponent<Destructible>();
        if(destructible != null)
        {
            destructible.ApplyDamage(25);
        }
    }
}
