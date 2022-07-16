using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private float _cameraHeight = 10.0f;
    [SerializeField] private Rigidbody _followTarget = null;
    private Transform _ownTransform = null;
    private Vector3 _initialVectorToTarget = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        _ownTransform = GetComponent<Transform>();
        _initialVectorToTarget = _followTarget.transform.position - _ownTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //_newPosition.x = _followTarget.position.x;
        //_newPosition.z = _followTarget.position.z;
        Vector3 nextDirection = new Vector3(_followTarget.position.x, _cameraHeight, _followTarget.position.z) - _initialVectorToTarget;
        _ownTransform.position = nextDirection;
    }
}
