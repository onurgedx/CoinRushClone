using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerExtraCoinController : MonoBehaviour
{

    [SerializeField] private Transform _mainCoinFollowReferance;

    [SerializeField] private PlayerExtraCoinData _playerExtraCoinData;

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;


    [SerializeField] private PlayerExtraCoinRemover _playerCoinRemover;
    [SerializeField] private LevelGenerator _levelGenerator;

    public Action ControlCoinsEvent;


    





    private void OnEnable()
    {
        _playerCoinRemover.OnBeforeRemoveAllExtraCoins += LostControlsOfCoins;
        _playerExtraCoinData.OnHasOneCoin += TurnOnControl;
        _playerExtraCoinData.OnHasNoCoin += TurnOffControl;
        _playerCollisionChecker.OnFinal += MakeExtraCoinsJump;

    }
    private void OnDisable()
    {
        _playerCoinRemover.OnBeforeRemoveAllExtraCoins -= LostControlsOfCoins;
        _playerExtraCoinData.OnHasOneCoin -= TurnOnControl;
        _playerExtraCoinData.OnHasNoCoin -= TurnOffControl;
        _playerCollisionChecker.OnFinal -= MakeExtraCoinsJump;


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


    private void MakeExtraCoinsJump()
    {


        TurnOffControl();
        StartCoroutine(MakeExtraCoinsJumpIEnumerator(_levelGenerator.BlocksOfUpstair));

    }


    private IEnumerator MakeExtraCoinsJumpIEnumerator(List<GameObject> blocks)
    {
        float arriveDuration = 0.7f;
        int blockNumber = 0;

        
        foreach (IExtraCoin extraCoin in _playerExtraCoinData.ExtraCoinList)
        {
            yield return new WaitForSeconds(arriveDuration);
            blockNumber++;
            extraCoin.GetGameObject().transform.DOJump(blocks[blockNumber].transform.position+Vector3.up, 1, 1,arriveDuration).OnComplete(() => extraCoin.Lose());


        }
        LevelManager.Instance.OnLevelFinishedAsSucces?.Invoke();

    }


}
