using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAndRotationResetter : MonoBehaviour
{
    private Quaternion _firstRotationRecorded;
    private Vector3 _firstScaleRecorded;

    private void Awake()
    {


        _firstRotationRecorded = transform.rotation;
        _firstScaleRecorded = transform.localScale;




    }

    private void Start()
    {

        LevelManager.Instance.OnLevelLoad += SetFirstSettings;

        
    }


    private void SetFirstSettings()
    {
        transform.rotation = _firstRotationRecorded;
        transform.localScale = _firstScaleRecorded;

    }
}
