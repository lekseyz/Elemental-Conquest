using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] private int _MaxHealth = 75;
    [SerializeField] private int _currentHealth = 75;
    Animator _animator;
    public PatrolerKnight patroler;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void takeDamage(int dmg)
    {
        _currentHealth -= dmg;
    }

    public void Update()
    {
        if (_currentHealth <= 0) {
            _animator.SetTrigger("Destroy");
        }
    }
}
