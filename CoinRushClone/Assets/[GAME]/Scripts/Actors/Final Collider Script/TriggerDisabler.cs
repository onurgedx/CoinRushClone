using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisabler : MonoBehaviour
{


    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void Start()
    {

        LevelManager.Instance.OnLevelLoad += SetColliderNotTrigger;
        
    }

    private void SetColliderNotTrigger()
    {
        _collider.isTrigger = false;

    }

}
