using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionChecker : MonoBehaviour
{

    public Action OnGainCoin;
    public Action OnCollideObstacle;


    
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.TryGetComponent(out IGainable gainable))
        {
            OnGainCoin?.Invoke();
            gainable.BeGained();

        }
        
        if(collision.gameObject.TryGetComponent(out IObstacle obstacle))
        {
            OnCollideObstacle?.Invoke();

        }
    }
}
