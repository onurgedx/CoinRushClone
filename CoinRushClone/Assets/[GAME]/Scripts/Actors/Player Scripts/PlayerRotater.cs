using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{

    [SerializeField] private Transform _coinTransform;
    [SerializeField] private Transform _targetToLook;
    [SerializeField] private PlayerDeadActor _playerDeadActor;
    [SerializeField] private PlayerLevelArragements _playerLevelArragements;
    private Action RotateEvent; 

    private void OnEnable()
    {
        _playerLevelArragements.OnBeAliveSettings += TurnOnRotateAbility;
        _playerDeadActor.OnDead += TurnOffRotateAbility;
        
    }
    private void OnDisable()
    {
        _playerLevelArragements.OnBeAliveSettings -= TurnOnRotateAbility;
        _playerDeadActor.OnDead -= TurnOffRotateAbility;
        TurnOffRotateAbility();
    }

    private void TurnOnRotateAbility()
    {
        RotateEvent = Rotate;

    }
    private void TurnOffRotateAbility()
    {
        RotateEvent =null;


    }

    private void Update()
    {
        RotateEvent?.Invoke();
    }

    private void Rotate()
    {

        Quaternion targetRotation = Quaternion.LookRotation(_targetToLook.position - _coinTransform.position);
        _coinTransform.rotation = Quaternion.Lerp(_coinTransform.rotation, targetRotation, Time.deltaTime*10);


    }
}
