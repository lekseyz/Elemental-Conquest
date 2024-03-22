using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private Collider2D collision;


    private void Start()
    {
        collision = GetComponent<PolygonCollider2D>();
    }
    public List<Collider2D>  GetCols()  {
        List<Collider2D> cols = new List<Collider2D>();
        
        Physics2D.OverlapCollider(collision, new ContactFilter2D().NoFilter(), cols);
        return cols.Where(x => x.tag == "Interactable").ToList();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag != "Interactable") return;

    //    if (!colliders.Contains(collision)) colliders.Add(collision);    
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(colliders.Contains(collision)) colliders.Remove(collision);
    //}
}
