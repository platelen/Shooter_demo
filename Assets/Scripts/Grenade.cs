using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _delay; //Задержка взрыва
    [SerializeField] private float _radiusExplossion; //Радиус взрыва
    [SerializeField] private float _forceExplossion; //Сила взрыва.
    [SerializeField] private float _damage; //Урон от взрыва
    [SerializeField] GameObject _explosionEffect;

    private Health _health;
    private float _countdown;
    private bool _hasExplode;

    void Start()
    {
        _countdown = _delay;
    }

    void Update()
    {
        _countdown -= Time.deltaTime;
        if (_countdown <= 0 && !_hasExplode)
        {
            Explode();
            _hasExplode = true; //Был взрыв.

        }

        void Explode()
        {
            Instantiate(_explosionEffect, transform.position, transform.rotation);
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplossion);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(_forceExplossion, transform.position, _radiusExplossion);

                }

            }

            Destroy(gameObject);
        }
    }
}
