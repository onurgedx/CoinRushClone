using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinRotater : MonoBehaviour
{
    [SerializeField] private ExtraCoin _extraCoin;


    Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    private void OnEnable()
    {
        _extraCoin.OnRotation += Rotate;
    }
    private void OnDisable()
    {
        _extraCoin.OnRotation -= Rotate;

    }
    private void Rotate(Transform leadTransform)
    {

        Vector3 destinationPosition = leadTransform.position;
        Vector3 directionForLooking = destinationPosition - _transform.position;
        Quaternion destinationQuaternion = Quaternion.LookRotation(directionForLooking);
        _transform.rotation  = Quaternion.Lerp(_transform.rotation,destinationQuaternion, Time.deltaTime*4);

    }
}
