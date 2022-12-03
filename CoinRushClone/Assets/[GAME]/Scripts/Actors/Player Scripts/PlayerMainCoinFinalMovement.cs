using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMainCoinFinalMovement : MonoBehaviour
{
    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;
    [SerializeField] private GameObject _jumpDestinationBlock;

    [SerializeField] private Transform _coinmodelTransform;

    public Action OnArriveFinalBlock;
    void Start()
    {
        _playerCollisionChecker.OnFinal += JumpToDestinationBlock;
        
    }

    private void JumpToDestinationBlock()
    {
        _coinmodelTransform.DOJump(_jumpDestinationBlock.transform.position+Vector3.up,1,1,0.76f).OnComplete(()=> OnArriveFinalBlock?.Invoke()); 

    }
}
