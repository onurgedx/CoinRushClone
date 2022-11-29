using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGainableCollisionController : MonoBehaviour
{


    public Action OnCollide;



    private void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent(out IPlayer player))
        {


            OnCollide?.Invoke();

        }

        
    }



}
