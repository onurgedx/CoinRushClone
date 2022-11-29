using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoin : MonoBehaviour, IExtraCoin
{

    public Action<Transform> OnMovement;
    public Action<Transform> OnRotation;
    public Action OnLose;


    [SerializeField] private Transform _referanceToFollow;
    [SerializeField] private Transform _modelTransform;
    public GameObject GetGameObject()
    {
        return gameObject;
    }
    public Transform GetModelTransform()
    {
        return _modelTransform;
    }

    public Transform GetReferanceFollowTransform()
    {
        return _referanceToFollow;
    }

    public void Lose()
    {
        OnLose?.Invoke();
        OnMovement = null;
        OnRotation = null;
    }

    public void SetExtraCoinPositionAndRotate(Transform leadCoin)
    {
        OnMovement?.Invoke(leadCoin);
        OnRotation?.Invoke(leadCoin);

        
    }

   
}
