using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEntityManager : MonoSingleton<CoinEntityManager>
{


    public Action<int> OnCoinCountChange;

    public int CoinCountPlayerHave
    {
        get
        {
            
            return _coinCountPlayerHave;

        }

        set
        {
            _coinCountPlayerHave = value;

            PlayerPrefs.SetInt(GlobalStrings.CoinCount, _coinCountPlayerHave);

            OnCoinCountChange?.Invoke(_coinCountPlayerHave);

        }

    }

    private int _coinCountPlayerHave;

    private void Awake()
    {

        _coinCountPlayerHave = PlayerPrefs.GetInt(GlobalStrings.CoinCount,0);

    }






}
