using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth, _healthNow;

    private bool _isDead;
    void Start()
    {
        
    }
    public void GetHit(int damage)
    {
        if (_isDead)
        {
            return;
        }

        int health = _healthNow - damage;
        if (health <= 0)
        {
            _isDead = true;
            Destroy(gameObject);
        }

        _healthNow = health;
    }

}
