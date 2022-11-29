using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraCoinRemover : MonoBehaviour
{



    public Action OnBeforeRemoveAllExtraCoins;



    [SerializeField] private PlayerExtraCoinData _playerExtraCoinData;

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;

    
    


    private void OnEnable()
    {

        _playerCollisionChecker.OnCollideObstacle += RemoveAllCoins;

    }
    private void OnDisable()
    {
        _playerCollisionChecker.OnCollideObstacle -= RemoveAllCoins;

    }
 
    private void RemoveAllCoins()
    {
        OnBeforeRemoveAllExtraCoins?.Invoke();
        _playerExtraCoinData.RemoveAllCoinsFromCoinList();

    }



}
