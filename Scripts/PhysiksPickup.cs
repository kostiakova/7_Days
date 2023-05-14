<<<<<<< HEAD
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PhysiksPickup : MonoBehaviour
{
    [SerializeField]private LayerMask _pickupMask;
    [SerializeField]private Camera _playerCamera;
    [SerializeField]private float _pickupRange;

    [SerializeField]private Rigidbody _currnetObjectRigidbody;
    private Collider _currntObjectCollider;
    public Transform _hand;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray PickupRay = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
            if (Physics.Raycast(PickupRay, out RaycastHit hitInfo, _pickupRange, _pickupMask))
            {
                _currnetObjectRigidbody.position = _hand.position;
                _currnetObjectRigidbody.rotation = _hand.rotation;

                if (_currnetObjectRigidbody)
                {

                }
                else
                {
                    _currnetObjectRigidbody = hitInfo.rigidbody;
                    _currntObjectCollider = hitInfo.collider;
                    _currnetObjectRigidbody.isKinematic = true;
                    _currntObjectCollider.enabled = false;

                }
            }
            if(_currnetObjectRigidbody)
            {
                
            }

        }

    }
      
}
=======
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
>>>>>>> c12922ad3d961c3f2fd4fe41c8bd997e9cc95982
