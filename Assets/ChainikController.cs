using UnityEngine;

public class ChainikController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    [SerializeField] private int damageAmount = 10; 
    private Animator animator;
    private SliderController sliderController;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        sliderController.UpdateSliderVal(currentHealth, maxHealth); 
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        sliderController = FindObjectOfType<SliderController>();
        sliderController.UpdateSliderVal(currentHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var destructible = collision.gameObject.GetComponent<Destructible>();
            destructible.ApplyDamage(10);
        }
    }


}
