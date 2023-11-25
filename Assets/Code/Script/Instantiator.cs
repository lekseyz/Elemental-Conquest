using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] float offset = 1;
    [SerializeField] float angle;
    Vector3 dir;


    public void instatiateMagic(BasicSpell spell)
    {
        if (spell == null) return;

        spell.activate(this.gameObject, dir, angle);
    }

    public void setPosition(Vector3 dir)
    {
        this.dir = dir;
        Transform playerT = GetComponentInParent<Transform>();
        transform.localPosition = dir * offset;
        angle = getAngle(new Vector2(dir.x, dir.y));

        transform.rotation = Quaternion.Euler(0, 0, (angle + Mathf.PI / 2) * Mathf.Rad2Deg);

        
    }

    private float getAngle(Vector2 dir)
    {
        float asin = Mathf.Asin(dir.y / dir.magnitude);
        float acos = Mathf.Acos(dir.x / dir.magnitude);

        if (acos > Mathf.PI / 2)
        {
            return Mathf.PI - asin;
        }
        return asin;
    }
}
