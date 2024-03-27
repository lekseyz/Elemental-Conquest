using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Rock : BasicSpell
{
    public GameObject Rocky;
    private int StoneCnt=0;
    public override void activate(GameObject parent, Vector3 dir, float angle)
    {
        Rocky.transform.position = parent.transform.position + dir;
        Instantiate(Rocky);
    }
} 
