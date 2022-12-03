using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{


    [SerializeField] private Transform _parentPool;

    public Transform PoolTransform
    {
        get { return _parentPool; }
    }

    [SerializeField] private ExtraCoin _extraCoinPrefabK;

    private IExtraCoin _extraCoinPrefab;

    private List<IExtraCoin> _extraCoinsList = new List<IExtraCoin>();



    [Serializable]
    private class PrefabAndListForPool
    {
        public GameObject Prefab;
        public List<GameObject> PoolList = new List<GameObject>();




    }




    [SerializeField]
    private PrefabAndListForPool AxePool, GainableCoinPool,PlusObstaclePool,RiserPool;










    private void Awake()
    {


    }
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

        GameObject extraCoinGo = Instantiate(_extraCoinPrefab.GetGameObject(), _parentPool);
        IExtraCoin extraCoin = extraCoinGo.GetComponent<IExtraCoin>();
        extraCoin.GetGameObject().SetActive(true);
        _extraCoinsList.Add(extraCoin);

        return extraCoin;


    }


    private GameObject GetWantedGameObject(PrefabAndListForPool prefabAndListForPool)
    {

        foreach (GameObject goExist in prefabAndListForPool.PoolList)
        {

            if (!goExist.activeInHierarchy)
            {

                goExist.SetActive(true);

                return goExist;


            }


        }

        GameObject go = Instantiate(prefabAndListForPool.Prefab, _parentPool);

        go.SetActive(true);
        prefabAndListForPool.PoolList.Add(go);

        return go;


    }

    public GameObject GetAxeGameObject()
    {
        return GetWantedGameObject(AxePool);
    }

    public GameObject GetGainableCoinGameObject()
    {

        return GetWantedGameObject(GainableCoinPool);

    }

    public GameObject GetPlusObstacleGameObject()
    {
        return GetWantedGameObject(PlusObstaclePool);
    }

    public GameObject GetRiserObstacleGameObject()
    {
        return GetWantedGameObject(RiserPool);
    }


    public GameObject GetRandomLevelActor()
    {
        int randomNumber = UnityEngine.Random.Range(0, 4);
        switch (randomNumber)
        {
            case 0:
                return GetPlusObstacleGameObject();
            case 1:
                return GetGainableCoinGameObject();
            case 2:
                return GetAxeGameObject();
            case 3:
                return GetRiserObstacleGameObject();


        }

        return GetAxeGameObject();

    }

}
