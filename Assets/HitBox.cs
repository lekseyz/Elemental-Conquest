using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public SortedSet<Collider2D> colliders = new SortedSet<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Interactable") return;

        if (!colliders.Contains(collision)) colliders.Add(collision);    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(colliders.Contains(collision)) colliders.Remove(collision);
    }
}
