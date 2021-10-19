using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Bot : MonoBehaviour
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

    private float _nextfire = 0f; //Задержка выстрела
    private Health _health;

}
