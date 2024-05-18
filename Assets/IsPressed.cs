using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPressed : MonoBehaviour
{
    [SerializeField] Spike spike;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null)
        {
            spike.isActive = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            spike.isActive = true;
        }
    }
}
