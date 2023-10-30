using System;
using UnityEditor.Timeline.Actions;
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

    private float activeSpeed;
    public float dashSpeed;

    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private float dashCounter=0;
    private float dashCoolCounter=0;

    
    private void Start()
    {
        activeSpeed = speed;
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
        movement.Normalize();
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
        //Dash implementation
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if ((dashCoolCounter<=0)&&(dashCounter<=0))
            {
                activeSpeed=dashSpeed;
                dashCounter=dashDuration;
            }
        }
        if (dashCounter>0)
        {
            dashCounter-=Time.deltaTime;
            dashCoolCounter = dashCooldown;
        }
        else
            activeSpeed = speed;
        if (dashCoolCounter>0)
        {
            dashCoolCounter-=Time.deltaTime;
        }

}
private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * activeSpeed * Time.fixedDeltaTime);
    }
}
