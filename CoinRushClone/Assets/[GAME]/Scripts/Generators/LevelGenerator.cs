using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    
    

    [SerializeField] private Transform _leftBoundReference;

    [SerializeField] private Transform _rightBoundReference;

    [SerializeField] private Transform _finalUpstairTransform;


    public List<GameObject> BlocksOfUpstair;

    private int _blockCountForUpstair;

    private void Start()
    {
        LevelManager.Instance.OnLevelLoad += ResetLevel;
        LevelManager.Instance.OnLevelLoad += CreateLevel;
        CreateLevel();
    }
    private void ResetLevel()
    {
        ObjectPoolManager.Instance.PoolTransform.DeactiveChilTransforms();
    }

    private void CreateLevel()
    {

        IPositionable lastPositionable = null;

        int gainableCoinCount = 1;

        int countActor = LevelManager.Instance.LevelNumber + 14;
        for (int i = 3; i <countActor; i++)
        {



            GameObject levelActorGo = ObjectPoolManager.Instance.GetRandomLevelActor();
            Vector3 randomPos = new Vector3(Random.Range(_leftBoundReference.position.x, _rightBoundReference.position.x), -1, 10 + i * 5);
            levelActorGo.transform.position = randomPos;



            levelActorGo.GetComponent<IPositionable>().SetPositionAndRotation(_leftBoundReference, _rightBoundReference, i, lastPositionable);

            lastPositionable = levelActorGo.GetComponent<IPositionable>();

            if(lastPositionable.Type == PositionableTypeEnum.CoinGainable)
            {
                gainableCoinCount++;
            }


        }


        SetFinalUpstair(gainableCoinCount,countActor);



    }



    private void SetFinalUpstair(int gainbleCointCount,int countOfActors)
    {
        for (int i = 0; i < gainbleCointCount; i++)
        {
            if (BlocksOfUpstair.Count > i)
            {
                
                BlocksOfUpstair[i].SetActive(true);

            }
            else
            {
                GameObject goNewBlock = Instantiate(BlocksOfUpstair[i - 1],BlocksOfUpstair[i-1].transform.parent);

                Vector3 extents = goNewBlock.GetComponent<Collider>().bounds.extents;
                goNewBlock.transform.position = BlocksOfUpstair[i - 1].transform.position + new Vector3(0, 2*extents.y, 2*extents.z);

                BlocksOfUpstair.Add(goNewBlock);



            }


        }


        _finalUpstairTransform.position = new Vector3(0,-1.25f,(countOfActors+5) * 3);


    }


}
