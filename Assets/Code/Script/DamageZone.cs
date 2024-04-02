using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float damageRate;
    private Destructible destructible;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= damageRate && destructible != null)
        {
            destructible.ApplyDamage(damage);
            timer = 0;
        }
    }

    public void setDistractible(Destructible destructible)
    {
        this.destructible = destructible;
    }

    public void resetDestractible()
    {
        this.destructible = null;
    }
}
