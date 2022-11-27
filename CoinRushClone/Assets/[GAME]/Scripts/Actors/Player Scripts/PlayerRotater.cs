using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{

    [SerializeField] private Transform _coinTransform;
    [SerializeField] private Transform _targetToLook;



  

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {

        Quaternion targetRotation = Quaternion.LookRotation(_targetToLook.position - _coinTransform.position);
        _coinTransform.rotation = Quaternion.Lerp(_coinTransform.rotation, targetRotation, Time.deltaTime*10);




    }
}
