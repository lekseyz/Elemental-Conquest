using UnityEngine;
using UnityEngine.Events;
public class Destructible : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;
    [SerializeField] private GameObject image;
    public UnityEvent Die;
    public UnityEvent ChangeHP;
    private int hitPoints;
    bool isTakeDamage;
    public bool isShielded;
    private float timer;
    private float maxTimer = 1f;
    private void Start()
    {
        isTakeDamage = false;
        hitPoints = maxHitPoints;
        ChangeHP.Invoke();
    }
   
    public void ApplyDamage(int damage)
    {
        if (!isShielded)
        {
            isTakeDamage = true;
            hitPoints -= damage;
            image.SetActive(true);
            ChangeHP.Invoke();
            if (hitPoints <= 0)
            {
                Kill();
            }
        }
    }

    private void Update()
    {

        if (isTakeDamage == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > maxTimer)
        {
            isTakeDamage = false;
            image.SetActive(false);
            timer = 0;
        }

    }

    public void Kill()
    {
        hitPoints = 0;
        maxHitPoints = 0;
        ChangeHP.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }
    public int GetMaxHitPoints()
    {
        return maxHitPoints;
    }
}
