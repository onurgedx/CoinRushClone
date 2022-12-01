using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private Transform _leftBoundReference;
    [SerializeField] private Transform _rightBoundReference;



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

        for (int i = 3; i < LevelManager.Instance.LevelNumber + 14; i++)
        {



            GameObject levelActorGo = ObjectPoolManager.Instance.GetRandomLevelActor();
            Vector3 randomPos = new Vector3(Random.Range(_leftBoundReference.position.x, _rightBoundReference.position.x), -1, 10 + i * 5);
            levelActorGo.transform.position = randomPos;



            levelActorGo.GetComponent<IPositionable>().SetPositionAndRotation(_leftBoundReference, _rightBoundReference, i, lastPositionable);
            lastPositionable = levelActorGo.GetComponent<IPositionable>();










        }





    }





}
