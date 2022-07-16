using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _startingHeight = 5.0f;
    [SerializeField] private float _explosionForce = 500.0f;
    [SerializeField] private float _explosionRadius = 5.0f;
    [SerializeField] private Rigidbody _rigidbody = null;

    //private void Start()
    //{
    //    _rigidbody = 
    //}

    void Update()
    {
        Vector3 vector = new Vector3(Input.mousePosition.normalized.x, _rigidbody.position.y, Input.mousePosition.normalized.y);
        //Debug.Log(vector);
        _rigidbody.position = vector;

        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDiceRandomly();
        }
    }

    private void RollDiceRandomly()
    {
        // Add a random force
        Vector3 dummyVector = new Vector3(0,1,0);
        _rigidbody.AddExplosionForce(_explosionForce, dummyVector, 1);
    }
}
