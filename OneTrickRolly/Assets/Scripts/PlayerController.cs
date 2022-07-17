using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _startingHeight = 5.0f;
    [SerializeField] private Rigidbody _rigidbody = null;

    #region Random throw
    [Header("Debug")]
    [SerializeField][Range(-4.0f, 4.0f)] private float _throwMinX = 0.0f;
    [SerializeField][Range(-4.0f, 4.0f)] private float _throwMaxX = 0.0f;
    [SerializeField][Range(-6.0f, 6.0f)] private float _throwMinZ = 0.0f;
    [SerializeField][Range(-6.0f, 6.0f)] private float _throwMaxZ = 0.0f;
    #endregion Random throw

    #region Debug
    [Header("Debug")]
    [SerializeField] private Vector3 _explosionDirection = new Vector3(0,1,0);
    [SerializeField] private Vector3 _explosionPosition = new Vector3(0,1,0);
    [SerializeField] private float _explosionForce = 500.0f;
    [SerializeField] private float _explosionRadius = 5.0f;
    #endregion Debug

    #region Internals
    private bool _isDropped = false;
    private Vector3 _initialPosition = Vector3.zero;
    private Vector3 _directionVector = Vector3.zero;
    #endregion Internals

    private void Start()
    {
        Debug.Log("Screen height :" + Screen.height);
        Debug.Log("Screen width :" + Screen.width);

        _isDropped = false;
        _initialPosition = transform.position;
    }

    private void Update()
    {
        HandleInput();
        ComputeNextSteeringPosition();
    }

    private void ComputeNextSteeringPosition()
    {
        float X = Input.mousePosition.x * GameManager.Instance.CurrentLevel.PlaneWidth / Screen.width;
        float Z = Input.mousePosition.y * GameManager.Instance.CurrentLevel.PlaneHeight / Screen.height;
        _directionVector = new Vector3(X, _rigidbody.position.y, Z);
    }

    void LateUpdate()
    {
        if (!_isDropped)
        {
            _rigidbody.MovePosition(_directionVector);
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDiceRandomly();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDice();
        }
    }

    private void RollDiceRandomly()
    {
        _isDropped = true;

        // Add a random force
        EnableDicePhysic();
        //_rigidbody.AddExplosionForce(_explosionForce, _explosionDirection, 1);
        _rigidbody.AddForceAtPosition(_explosionDirection, _explosionPosition, ForceMode.Impulse);
    }

    private void EnableDicePhysic()
    {
        _rigidbody.isKinematic = false;
    }

    private void ResetDice()
    {
        _rigidbody.isKinematic = true;
        transform.position = _initialPosition;

        // Keep it at the end
        _isDropped = false;
    }
}
