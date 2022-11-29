using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    [SerializeField] private ExtraCoin _extraCoinPrefabK;
     private IExtraCoin _extraCoinPrefab;
    private List<IExtraCoin> _extraCoinsList = new List<IExtraCoin>();

    private void Start()
    {

        _extraCoinPrefab = _extraCoinPrefabK;

    }
    public IExtraCoin GetExtraCoin()
    {

        foreach (IExtraCoin extraCoinf in _extraCoinsList)
        {

            if (!extraCoinf.GetGameObject().activeInHierarchy)
            {

                extraCoinf.GetGameObject().SetActive(true);

                return extraCoinf;


            }


        }

        GameObject extraCoinGo = Instantiate(_extraCoinPrefab.GetGameObject());
        IExtraCoin extraCoin = extraCoinGo.GetComponent<IExtraCoin>();
        extraCoin.GetGameObject().SetActive(true);
        _extraCoinsList.Add(extraCoin);

        return extraCoin;


    }






}
