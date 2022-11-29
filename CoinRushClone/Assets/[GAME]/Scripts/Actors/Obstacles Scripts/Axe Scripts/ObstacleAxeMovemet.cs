using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ObstacleAxeMovemet : MonoBehaviour
{


    public float DestinationXAngle = -17f;
    public float AxeArriveDuration = 0.3f;

    [SerializeField] private ObstacleAxeTriggerCheker _obstacleAxeTriggerCheker;


    private void OnEnable()
    {
        _obstacleAxeTriggerCheker.OnPlayerTrigged += Rotate;
    }

    private void OnDisable()
    {
        _obstacleAxeTriggerCheker.OnPlayerTrigged -= Rotate;

    }

    public void Rotate()
    {

        transform.DOLocalRotate(Vector3.right* DestinationXAngle, AxeArriveDuration).SetEase(Ease.InBack);


    }


}
