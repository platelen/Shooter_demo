using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Look : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void LateUpdate()
    {
        transform.LookAt(_target.transform.position);
    }
}
