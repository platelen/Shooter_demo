using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot_Walk : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] float _timer;
    [SerializeField] float _newTimer;

    private bool _Isyes;
    

    void Start()
    {
        _newTimer = _timer;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _EnemyPrefab.GetComponent<NavMeshAgent>().enabled = true;
            _EnemyPrefab.GetComponent<Animator>().SetTrigger("Walk");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _Isyes = true;
        }
    }

    void Update()
    {
        if (_Isyes == true)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer < 0)
        {
            _EnemyPrefab.GetComponent<NavMeshAgent>().enabled = false;
            _Isyes = false;
            _timer = _newTimer;
            _EnemyPrefab.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
