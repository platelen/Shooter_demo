using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Стрельба.
    /// </summary>
public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damage;    //урон.
    [SerializeField] private float _fireRate; //задержка выстрела.
    [SerializeField] private float force; //сила выстрела
    [SerializeField] private float _fireRange; //дальность стрельбы.
    [SerializeField] private Transform _bulletSpawn; //появление пули.
    [SerializeField] private ParticleSystem _shootingEffect; //частицы стрельбы.
    [SerializeField] private AudioClip _shootClip; //звук выстрела.
    [SerializeField] private AudioSource _audioSource; //источник звука.
    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _projectWall, _projectEnmey;
    [SerializeField] private int maxProjectors;

    private Health _health;
    private float nextFire = 0f; //интервал стрельбы.
    
    void Start()
    {

    }
    void Shoot()
    {
        _audioSource.PlayOneShot(_shootClip);
        _shootingEffect.Play();

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, _fireRange))
        {
            //GameObject impact = Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
            //Destroy(impact,2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal*force);
                _health = GameObject.FindObjectOfType<Health>();
                _health.GetHit(_damage);
            }
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }
}
