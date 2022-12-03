using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCoinLevelArragement : MonoBehaviour
{


    [SerializeField] private Rigidbody _coinRigidbody;
   
    
    private Quaternion _recordedFirstQuaternionCoin;

    private void OnEnable()
    {

        TurnOnKinematicForAlive();

        SetFirstLocalPositionOfCoin();

        SetFirstQuaternionSettingsOfCoin();


    }
    private void TurnOnKinematicForAlive()
    {
        _coinRigidbody.isKinematic = true;

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
