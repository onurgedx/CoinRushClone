using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotater : MonoBehaviour
{
    [SerializeField] private Transform _coinModel;
    // Start is called before the first frame update

    private Action SpinEvent; 
    
    void Start()
    {
        LevelManager.Instance.OnLevelStarted += SetSpinOn;
        LevelManager.Instance.OnLevelFinished += SetSpinOff;
        


    }

    // Update is called once per frame
    void Update()
    {
        SpinEvent?.Invoke();
        
    }

    private void SetSpinOn()
    {
        SpinEvent = SpinCoin;
    }

    private void SetSpinOff()
    {
        SpinEvent = null;
    }
    
    private void SpinCoin()
    {

        _coinModel.Rotate(Vector3.back* Time.deltaTime * Speeds.CoinSpinSpeed,Space.Self);



    }


}
