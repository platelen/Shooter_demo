using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vault_Room : MonoBehaviour
{
    [SerializeField] private GameObject _Zoom;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vault_R")
        {
            _Zoom.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vault_R")
        {
            _Zoom.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
