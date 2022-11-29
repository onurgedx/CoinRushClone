using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAxeTriggerCheker : MonoBehaviour
{


    public Action OnPlayerTrigged;



    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out IPlayer player))
        {

            OnPlayerTrigged?.Invoke();

        }



    }



}
