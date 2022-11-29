using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraCoinController : MonoBehaviour
{

    [SerializeField] private Transform _mainCoinFollowReferance;

    [SerializeField] private PlayerExtraCoinData _playerExtraCoinData;

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;


    [SerializeField] private PlayerExtraCoinRemover _playerCoinRemover;

    public Action ControlCoinsEvent;



    private void OnEnable()
    {
        _playerCoinRemover.OnBeforeRemoveAllExtraCoins += LostControlsOfCoins;
        _playerExtraCoinData.OnHasOneCoin += TurnOnControl;
        _playerExtraCoinData.OnHasNoCoin += TurnOffControl;
        
    }
    private void OnDisable()
    {
        _playerCoinRemover.OnBeforeRemoveAllExtraCoins -= LostControlsOfCoins;
        _playerExtraCoinData.OnHasOneCoin -= TurnOnControl;
        _playerExtraCoinData.OnHasNoCoin -= TurnOffControl;


    }
    // Update is called once per frame
    void Update()
    {
        ControlCoinsEvent?.Invoke();
    }


    private List<IExtraCoin> ExtraCoinList
    {
        get
        {

            return _playerExtraCoinData.ExtraCoinList;

        }
    }




    public void LostControlsOfCoins()
    {
        ControlCoinsEvent = null;
        foreach (IExtraCoin extraCoin in _playerExtraCoinData.ExtraCoinList)
        {
            extraCoin.Lose();


        }
       

    }

    private void TurnOnControl()
    {

        ControlCoinsEvent = ControlExtraCoins;
    }
    private void TurnOffControl()
    {
        ControlCoinsEvent = null;

    }

    private void ControlExtraCoins()
    {


        // i have used for instand of foreach  Because  This method calls on every Update. So
        //if(_extraCoinList.Count>0)
        ExtraCoinList[0]?.SetExtraCoinPositionAndRotate(_mainCoinFollowReferance);
        for (int i = 1; i < ExtraCoinList.Count; i++)
        {


            ExtraCoinList[i]?.SetExtraCoinPositionAndRotate(ExtraCoinList[i - 1].GetReferanceFollowTransform());

        }



    }


}
