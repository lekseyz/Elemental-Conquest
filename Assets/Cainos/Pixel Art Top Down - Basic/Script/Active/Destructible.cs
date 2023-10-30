using UnityEngine;
using UnityEngine.Events;
public class Destructible : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;

    public UnityEvent Die;
    public UnityEvent ChangeHP;
    private int hitPoints;


    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHP.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;
       // Debug.Log("Урон нанесен");
        ChangeHP.Invoke();
        if (hitPoints <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        hitPoints = 0;
        maxHitPoints=0;
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
