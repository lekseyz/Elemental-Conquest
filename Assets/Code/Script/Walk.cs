using System;
using UnityEngine.Timeline;
using UnityEngine;
using UnityEngine.UI;
public class Walk : MonoBehaviour
{
    [SerializeField] GameObject magicAplier;

    [SerializeField] public float speed;
    [SerializeField] Slider staminaSlider;
    Vector3 dir = Vector3.down;
    private Vector3 dirMov = Vector3.zero;
    Vector3 prevDirMov = Vector3.zero;
    public Vector3 Dir { get { return dir; } }
    float scSpeed = 1f;

    public Rigidbody2D rb;
    public Animator animator;

    private float activeSpeed;
    public float dashSpeed;

    public float dashDuration;
    public float dashCooldown;

    private float dashCounter = 0;
    private float dashCoolCounter = 0;

    private float staminaValue = 100;
    private bool isFirst = false;

    void Update()
    {
        Movement();
        magicAplier.GetComponent<Instantiator>().setPosition(dir);
        Dash(false);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.fixedDeltaTime = 0.01f;
        staminaSlider.value = 100;
    }
    private void Movement()
    {
        //rewrited character movement
        dirMov = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dirMov.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dirMov.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dirMov.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dirMov.y = -1;
        }


        dirMov = Vector3.Lerp(prevDirMov, dirMov, scSpeed);

        dirMov = dirMov.normalized;
        dir = dirMov.magnitude > 0 ? dirMov : dir;
        animator.SetBool("isMoving", rb.velocity.magnitude > 0);

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
    }

    public void Dash(bool isDashed)
    {

        if (isDashed)
        {
            if (dashCoolCounter <= 0f && dashCounter <= 0f)
            {
                isFirst = true;
                staminaValue = 100;
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
        {
            activeSpeed = speed;
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            staminaValue = Mathf.Lerp(100f, 0f, dashCoolCounter / dashCooldown);
            staminaSlider.value = staminaValue;
        }


        if (dashCoolCounter <= 0 && isFirst == true)
        {
            staminaValue = Mathf.Lerp(100f, 0f, 1 - dashDuration / dashCounter);
        }
    }

    private void FixedUpdate()
    { 
        rb.velocity = dirMov * activeSpeed;
    }
}