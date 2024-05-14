using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate = 1f;
    private Destructible destructible;
    private float timer;

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Destructible>().ApplyDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && destructible == other.GetComponent<Destructible>())
        {
            destructible = null;
        }
    }
}
