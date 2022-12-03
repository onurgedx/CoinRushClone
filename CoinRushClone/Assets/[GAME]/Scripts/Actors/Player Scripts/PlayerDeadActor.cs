using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadActor : MonoBehaviour
{
    
    [SerializeField] PlayerCollisionChecker _playerCollisionChecker;

    [SerializeField] private PlayerFallController _playerFallController;

    [SerializeField] private Rigidbody _coinRigidbody;
     
    public Action OnDead;



    private void Start()
    {

        LevelManager.Instance.OnLevelStarted += SetPlayerFallSettings;
       

        
    }

    private void SetPlayerFallSettings()
    {
        _playerFallController.OnPlayerFalled = Dead;

    }

    private void OnEnable()
    {
        _playerCollisionChecker.OnCollideObstacle += Dead;
        


         

    }

    private void OnDisable()
    {
        _playerCollisionChecker.OnCollideObstacle -= Dead;

       


    }




    private void Dead()
    {

        OnDead?.Invoke();
        LevelManager.Instance.OnLevelFinishedAsFail?.Invoke();

    }
    

    


    
}
