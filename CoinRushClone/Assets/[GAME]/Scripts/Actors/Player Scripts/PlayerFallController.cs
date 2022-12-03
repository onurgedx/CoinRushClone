using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallController : MonoBehaviour
{

    public Action OnPlayerFalled;

    [SerializeField] private GameObject _groundGo;


    

    // Update is called once per frame
    void Update()
    {
        FallCheker();

    }



    private void FallCheker()
    {
        if (transform.position.y < _groundGo.transform.position.y - 3)
        {

            OnPlayerFalled?.Invoke();
            OnPlayerFalled = null;
        }
    }


}
