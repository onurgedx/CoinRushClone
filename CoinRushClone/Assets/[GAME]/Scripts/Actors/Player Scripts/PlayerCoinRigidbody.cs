using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinRigidbody : MonoBehaviour
{


    [SerializeField] private Rigidbody _coinRigidbody;
    [SerializeField] private PlayerDeadActor _playerDeadActor;
    [SerializeField] private PlayerMainCoinFinalMovement _playerMainCoinFinalMovement;

    private void Start()
    {
        _playerMainCoinFinalMovement.OnArriveFinalBlock += TurnOffKinematicForFall;
        _playerDeadActor.OnDead+= TurnOffKinematicForFall;


    }
    private void TurnOffKinematicForFall()
    {
        _coinRigidbody.isKinematic = false;


    }


    private void TurnOnKinematicForAlive()
    {
        _coinRigidbody.isKinematic = true;
    }
}
