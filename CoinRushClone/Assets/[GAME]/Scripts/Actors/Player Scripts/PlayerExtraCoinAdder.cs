using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraCoinAdder : MonoBehaviour
{


    public Action OnCoinGained; 

    [SerializeField] private PlayerExtraCoinData _playerExtraCoinData;

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;


    private void OnEnable()
    {

        _playerCollisionChecker.OnGainCoin += AddNewCoin;

    }
    private void OnDisable()
    {
        _playerCollisionChecker.OnGainCoin -= AddNewCoin;
        
    }
    private void AddNewCoin()
    {


        _playerExtraCoinData.AddCoinToExtraCoinList( ObjectPoolManager.Instance.GetExtraCoin());

        OnCoinGained?.Invoke();





    }



}
