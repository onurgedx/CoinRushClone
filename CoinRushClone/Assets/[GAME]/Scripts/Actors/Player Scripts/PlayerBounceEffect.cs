using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerBounceEffect : MonoBehaviour
{


    public Action OnBounceStart; 
    public Action OnBounceEnd; 

    [SerializeField] private PlayerExtraCoinAdder _playerExtraCoinAdder;
    [SerializeField] private PlayerExtraCoinController _playerExtraCoinController;

    [SerializeField] private PlayerExtraCoinData _playerExtraCoinData;


    [SerializeField] private Transform _mainCoinModel;

    private WaitForSeconds _waitForSecondsForBounceDelay;
    public float BounceDelay = 0.051f;
    public float BounceGrowDuration = 0.2f;
    public float BounceShrinkDuration = 0.3f;


    private void Start()
    {
        _waitForSecondsForBounceDelay = new WaitForSeconds(BounceDelay);
    }
    private void OnEnable()
    {
        _playerExtraCoinAdder.OnCoinGained += BounceEffect;
    }
    private void OnDisable()
    {
        _playerExtraCoinAdder.OnCoinGained -= BounceEffect;


    }
    private void BounceEffect()
    {
        StartCoroutine(BounceEffectIEnumerator());



    }
    private IEnumerator BounceEffectIEnumerator()
    {

        OnBounceStart?.Invoke();

        //_mainCoinModel.DOKill(true);
        List<IExtraCoin> listOfCoins = _playerExtraCoinData.ExtraCoinList;

       
        _mainCoinModel.BounceEffect(2, BounceGrowDuration, BounceGrowDuration);
       
        
        for (int i = 0; i < listOfCoins.Count; i++)
        {
            
            yield return _waitForSecondsForBounceDelay;

            listOfCoins[i].GetModelTransform().BounceEffect(2, BounceGrowDuration, BounceGrowDuration);
            

        }
        yield return new WaitForSeconds(BounceDuration);
        OnBounceEnd?.Invoke();

    }

    public float BounceDuration
    {
        get { return BounceGrowDuration + BounceGrowDuration; }
    }

}
