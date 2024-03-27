using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDamage : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            other.gameObject.GetComponent<Interactable>().applyStone();
        }

        if (other.gameObject.tag != "Lava" && other.gameObject.tag != "Player")
        {
            animator.SetTrigger("Destroy");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length * 8f);
        }
    }
}
