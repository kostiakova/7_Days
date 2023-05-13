using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiksPickup : MonoBehaviour
{
    [SerializeField]private LayerMask _pickupMask;
    [SerializeField]private Camera _playerCamera;
    [SerializeField]private Transform _pickupPos;
    [Space]
    [SerializeField]private float _pickupRange;
    [SerializeField]private Rigidbody _currentObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_currentObject)
            {
                _currentObject.useGravity = true;
                _currentObject = null;
                return;
            }
            Ray CameraRay = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, _pickupRange, _pickupMask))
            {
                _currentObject = hitInfo.rigidbody;
                _currentObject.useGravity = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(_currentObject)
        {
            Vector3 DirectionToPoint = _pickupPos.position - _currentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            _currentObject.velocity = DirectionToPoint * 12 * DistanceToPoint;
        }
    }
}
