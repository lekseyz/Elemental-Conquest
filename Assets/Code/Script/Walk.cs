using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
public class Walk : MonoBehaviour
{
    [SerializeField] public float speed;

    Vector3 dir = Vector3.zero;
    Vector3 dirMov = Vector3.zero;
    Vector3 prevDirMov = Vector3.zero;
    float scSpeed = 1f;

    public Rigidbody2D rb;
    public Animator animator;

    private float activeSpeed;
    public float dashSpeed;

    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;

    private float dashCounter=0;
    private float dashCoolCounter=0;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.fixedDeltaTime = 0.01f;
    }


    void Update()
    {
        //rewrited charecter movement
        dirMov = Vector3.zero;

        if(Input.GetKey(KeyCode.A))
        {
            dirMov.x = -1;
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            dirMov.x = 1;
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            dirMov.y = 1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dirMov.y = -1;
        }

        dirMov = Vector3.Lerp(prevDirMov, dirMov, scSpeed);
        prevDirMov = dirMov;

        dirMov = dirMov.normalized;
        dir = dirMov.magnitude > 0 ? dirMov : dir;
        animator.SetBool("isMoving", rb.velocity.magnitude > 0);

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);

        


        //Dash implementation
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if ((dashCoolCounter <= 0) && (dashCounter <= 0))
            {
                activeSpeed = dashSpeed;
                dashCounter = dashDuration;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            dashCoolCounter = dashCooldown;
        }
        else
            activeSpeed = speed;
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dirMov * activeSpeed;
    }
}
