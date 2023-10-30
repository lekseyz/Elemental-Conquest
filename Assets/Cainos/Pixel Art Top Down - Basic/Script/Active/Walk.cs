using System;
using UnityEngine;
public class Walk : MonoBehaviour
{
    [SerializeField] public float speed;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    private bool StayUp;
    private bool StayRight;
    private bool StayLeft;
    private bool StayDown;
    private void Start()
    {
        StayLeft = false;
        StayRight = false;
        StayUp = false;
        StayDown = false;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement.sqrMagnitude > 0)
        {
            StayLeft = false;
            StayRight = false;
            StayUp = false;
            StayDown = false;
        }

        if ((movement.y == 1) && (StayLeft == false) && (StayRight == false) && (StayDown == false))
            StayUp = true;
        if ((movement.x == -1) && (StayUp == false) && (StayRight == false) && (StayDown == false))
            StayLeft = true;
        if ((movement.x == 1) && (StayLeft == false) && (StayUp == false) && (StayDown == false))
            StayRight = true;
        if ((movement.y == -1) && (StayLeft == false) && (StayUp == false) && (StayRight == false))
            StayDown = true;
  
        animator.SetBool("StayLeft", StayLeft);

        animator.SetBool("StayUp", StayUp);

        animator.SetBool("StayRight", StayRight);

        animator.SetBool("StayDown", StayDown);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
