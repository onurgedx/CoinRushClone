using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateController : MonoBehaviour
{

    [SerializeField] private Transform _targetTransformToLook;

    [SerializeField] private PlayerDeadActor _playerDeadActor;


    private void OnEnable()
    {
        _playerDeadActor.OnDead += TurnOffRotateControl;
        TurnOnRotateControl();

    }

    private void OnDisable()
    {

        _playerDeadActor.OnDead -= TurnOffRotateControl;
        TurnOffRotateControl();

    }

    private void TurnOnRotateControl()
    {InputController.OnTouch += SetRotatePosition;

    }
    private void TurnOffRotateControl()
    {InputController.OnTouch -= SetRotatePosition;

    }

    private void SetRotatePosition(float x)
    {
        
        Vector3 localPositionOfTargetTransformToLook = _targetTransformToLook.transform.localPosition;

        localPositionOfTargetTransformToLook.x = x;

        _targetTransformToLook.transform.localPosition = localPositionOfTargetTransformToLook;



    }

}
