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
