using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForward : MonoBehaviour
{


    [SerializeField] private Transform _coinTransform;
    [SerializeField] private PlayerDeadActor _playerDeadActor;


    public float PlayerSpeed = 10;

    public Action MovementEvent;


    private void OnEnable()
    {
        TurnOnMoveForward();
        _playerDeadActor.OnDead += TurnOffMoveForward;
    }

    private void OnDisable()
    {
        _playerDeadActor.OnDead -= TurnOffMoveForward;
        TurnOffMoveForward();
    }
    // Update is called once per frame
    void Update()
    {

        MovementEvent?.Invoke();



    }

    private void TurnOnMoveForward()
    {
        MovementEvent = MoveForward;
    }

    private void TurnOffMoveForward()
    {
        MovementEvent = null;
    }



    private void MoveForward()
    {


        transform.position += _coinTransform.forward * PlayerSpeed * Time.deltaTime;
        



    }

}
