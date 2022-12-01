using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinSpinner : MonoBehaviour
{

    [SerializeField] private Transform _coinModel;
    

    private Action SpinEvent;

    void Start()
    {

        LevelManager.Instance.OnLevelFinished += SetSpinOff;



    }
    private void OnEnable()
    {
        SetSpinOn();

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

        _coinModel.Rotate(Vector3.back * Time.deltaTime * Speeds.CoinSpinSpeed, Space.Self);



    }



}
