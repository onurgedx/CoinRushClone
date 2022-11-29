using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraCoinData : MonoBehaviour
{


    private List<IExtraCoin> _extraCoinList = new List<IExtraCoin>();

    public Action OnHasOneCoin;
    public Action OnHasNoCoin;



    public List<IExtraCoin> ExtraCoinList
    {
        get { return _extraCoinList; }
    }
    public void AddCoinToExtraCoinList(IExtraCoin extraCoin)
    {
        extraCoin.GetGameObject().transform.position = transform.position;
        _extraCoinList.Add(extraCoin);
        if (_extraCoinList.Count == 1)
        {
            OnHasOneCoin?.Invoke();

        }


    }

    public void RemoveCoinFromExtaCoinList()
    {

        _extraCoinList.RemoveAt(_extraCoinList.Count - 1);

        if (_extraCoinList.Count == 0)
        {
            OnHasNoCoin?.Invoke();
        }

    }

    public void RemoveAllCoinsFromCoinList()
    {
        _extraCoinList.Clear();


    }



}
