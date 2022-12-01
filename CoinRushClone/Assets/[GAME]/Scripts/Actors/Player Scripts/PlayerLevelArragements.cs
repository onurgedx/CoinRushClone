using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelArragements : MonoBehaviour
{

    [SerializeField] private Rigidbody _coinRigidbody;
    public Action OnBeAliveSettings;
    private Vector3 _recordedFirstPosition;
    private Quaternion _recordedFirstQuaternionCoin;
    // Start is called before the first frame update
    void Start()
    {
        _recordedFirstQuaternionCoin = _coinRigidbody.transform.localRotation;
        _recordedFirstPosition = transform.position;
        OnBeAliveSettings += TurnOnKinematicForAlive;
        OnBeAliveSettings += SetFirstPositionSetting;
        OnBeAliveSettings += SetFirstLocalPositionOfCoin;
        OnBeAliveSettings += SetFirstQuaternionSettingsOfCoin;
        LevelManager.Instance.OnLevelStarted += SetAlive;

    }

   

    private void SetAlive()
    {

        OnBeAliveSettings?.Invoke();



    }

    private void TurnOnKinematicForAlive()
    {
        _coinRigidbody.isKinematic = true;

    }

    private void SetFirstPositionSetting()
    {
        transform.position = _recordedFirstPosition;
    }
    private void SetFirstQuaternionSettingsOfCoin()
    {
        _coinRigidbody.transform.localRotation = _recordedFirstQuaternionCoin;
    }

    private void SetFirstLocalPositionOfCoin()
    {
        _coinRigidbody.transform.localPosition = Vector3.zero;
    }





}
