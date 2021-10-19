using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Vault : MonoBehaviour
{
    [SerializeField] private GameObject _Vault;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _Vault.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _Vault.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
