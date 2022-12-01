using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadActor : MonoBehaviour
{
    [SerializeField] PlayerCollisionChecker _playerCollisionChecker;


    [SerializeField] private Rigidbody _coinRigidbody;
     
    public Action OnDead;


    private void OnEnable()
    {
        _playerCollisionChecker.OnCollideObstacle += Dead;
        OnDead += TurnOffKinematicForFall;


         

    }

    private void OnDisable()
    {
        _playerCollisionChecker.OnCollideObstacle -= Dead;

        OnDead -= TurnOffKinematicForFall;


    }




    private void Dead()
    {

        OnDead?.Invoke();
        LevelManager.Instance.OnLevelFinishedAsFail?.Invoke();

    }
    

    private void TurnOffKinematicForFall()
    {
        _coinRigidbody.isKinematic = false;


    }


    private void TurnOnKinematicForAlive()
    {
        _coinRigidbody.isKinematic = true;
    }



    
}
