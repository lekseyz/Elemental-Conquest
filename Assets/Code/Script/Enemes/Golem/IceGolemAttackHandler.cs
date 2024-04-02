using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolemAttackHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destructible hui = collision.gameObject.GetComponent<Destructible>();
            if(hui != null) { hui.ApplyDamage(10); }
        }
    }
}
