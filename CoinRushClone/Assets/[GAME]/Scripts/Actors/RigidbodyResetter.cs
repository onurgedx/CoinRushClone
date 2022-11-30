using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyKinematicResetter : MonoBehaviour
{


    private Rigidbody _myRigidbody;

    private bool _isKinematic;
    
    private void Awake()
    {

        _myRigidbody = GetComponent<Rigidbody>();
        
        _myRigidbody.isKinematic = _isKinematic;


    }

    private void Start()
    {
        LevelManager.Instance.OnLevelLoad += ResetKinematicSetting;
    }


    private void ResetKinematicSetting()
    {
        
        _myRigidbody.isKinematic = _isKinematic;

    }



}
