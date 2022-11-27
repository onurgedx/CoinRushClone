using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateController : MonoBehaviour
{

    [SerializeField] private Transform _targetTransformToLook;
    private void OnEnable()
    {

        InputController.OnTouch += SetRotatePosition;

    }

    private void OnDisable()
    {

        InputController.OnTouch -= SetRotatePosition;

    }


    private void SetRotatePosition(float x)
    {
        
        Vector3 localPositionOfTargetTransformToLook = _targetTransformToLook.transform.localPosition;

        localPositionOfTargetTransformToLook.x = x;

        _targetTransformToLook.transform.localPosition = localPositionOfTargetTransformToLook;



    }

}
