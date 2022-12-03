using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinMovement : MonoBehaviour
{
    [SerializeField] private ExtraCoin _extraCoin;

    
    Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    private void OnEnable()
    {
        _extraCoin.OnMovement = Move;
    }
    private void OnDisable()
    {
        _extraCoin.OnMovement =null;
        
    }
    
    
    private void Move(Transform leadTransform)
    {

        Vector3 destinationPosition = leadTransform.position;

        _transform.position = Vector3.Lerp(_transform.position, destinationPosition,Time.deltaTime*Speeds.ExtraCoinSpeed);

    }
}
