using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinLoseState : MonoBehaviour
{

    [SerializeField] private Rigidbody _myRigidbody;
    [SerializeField] private ExtraCoin _extraCoin;

    private void Start()
    {


        _extraCoin.OnLose = Fall;
        
    }
    private void Fall()
    {
        _myRigidbody.isKinematic = false;
        _myRigidbody.AddForce(transform.forward * 10);
    }

}
