using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GrenadeThrowed : MonoBehaviour
{
    [SerializeField] private float _throwForce;
    [SerializeField] private Text text;
    [SerializeField] private GameObject _grenadePrefab;

    private const float _repeatThrow = 10f;
    private float _timeNow;
    private bool _IsReady;

    void Start()
    {
        text.text = _repeatThrow.ToString();
        _timeNow = _repeatThrow;

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowGrenade();

        }

        if (_IsReady)
        {

            _timeNow -= Time.deltaTime;
            text.text = _timeNow.ToString("0");
        }
        else
        {
            _timeNow = _repeatThrow;
            text.text = _repeatThrow.ToString("0");
        }

    }

    public void ThrowGrenade()
    {
        if (!_IsReady)
        {
            _IsReady = true;
            GameObject grenade = Instantiate(_grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * _throwForce, ForceMode.VelocityChange);
            Invoke("IsReady", _repeatThrow);

        }

    }
    void IsReady()
    {
        _IsReady = false;
    }

}
