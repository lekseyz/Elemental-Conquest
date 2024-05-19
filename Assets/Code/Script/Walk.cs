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

    // Звук для воспроизведения при dash
    public AudioSource dashSound;

    void Update()
    {
        Movement();
        // Проверка на наличие объекта magicAplier и его компонента Instantiator
        if (magicAplier != null && magicAplier.GetComponent<Instantiator>() != null)
        {
            // Установка позиции в соответствии с текущим направлением
            magicAplier.GetComponent<Instantiator>().setPosition(dir);
        }
        // Вызов метода Dash с аргументом false
        Dash(false);
    }

    private void Start()
    {
        // Получение Rigidbody2D при запуске
        rb = GetComponent<Rigidbody2D>();
        // Установка фиксированного шага времени
        Time.fixedDeltaTime = 0.01f;
        // Установка начального значения для полосы выносливости
        staminaSlider.value = 100;
    }

    private void Movement()
    {
        // Переписанное управление персонажем
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

        // Линейная интерполяция между предыдущим и текущим направлением движения
        dirMov = Vector3.Lerp(prevDirMov, dirMov, scSpeed);
        dirMov = dirMov.normalized;
        // Установка текущего направления
        dir = dirMov.magnitude > 0 ? dirMov : dir;
        // Установка параметров анимации
        animator.SetBool("isMoving", rb.velocity.magnitude > 0);
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
    }

    public void Dash(bool isDashed)
    {
        // Проверка, активирован ли рывок
        if (isDashed)
        {
            // Проверка, доступен ли рывок в данный момент
            if (dashCoolCounter <= 0f && dashCounter <= 0f)
            {
                isFirst = true;
                staminaValue = 100;
                activeSpeed = dashSpeed;
                dashCounter = dashDuration;

                // Воспроизведение звука при начале рывка
                if (dashSound != null)
                {
                    dashSound.Play();
                }
            }
        }

        // Уменьшение времени рывка и перезарядки
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
            // Изменение значения выносливости
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
        // Применение скорости движения
        rb.velocity = dirMov * activeSpeed;
    }
}
