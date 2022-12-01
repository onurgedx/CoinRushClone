using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraController : MonoBehaviour
{


    private Camera _mainCamera;

    [SerializeField] private Transform _cameraReferanceTransform;
    [SerializeField] private Transform _mainCoinTransform;
    



    public float CameraSpeed = 10f;
    public float CameraRotateSpeed = 10f;



    public Action CameraMovementEvent;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        
    }
    

    // Update is called once per frame
    void LateUpdate()
    {




        CameraMovementEvent?.Invoke();



    }

    private void OnEnable()
    {
        CameraMovementEvent += ControlCameraMovement;
        // CameraMovementEvent += ControlCameraRotate;
        LevelManager.Instance.OnLevelFinishedAsFail += ShakeCameraOnDead;

    }

    private void OnDisable()
    {
        CameraMovementEvent -= ControlCameraMovement;
       LevelManager.Instance.OnLevelFinishedAsFail -= ShakeCameraOnDead;
        //CameraMovementEvent -= ControlCameraRotate;
        
    }

    private void ControlCameraMovement()
    {

        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _cameraReferanceTransform.position,Time.deltaTime*CameraSpeed);
        
    }

    private void ControlCameraRotate()
    {

        Vector3 directionToLook = _mainCoinTransform.position - _mainCamera.transform.position;
        Quaternion _lookAtPlayerQuaternion = Quaternion.LookRotation(directionToLook);


        _mainCamera.transform.rotation = Quaternion.Lerp(_mainCamera.transform.rotation, _lookAtPlayerQuaternion, Time.deltaTime * CameraRotateSpeed);

    }
    

    private void ShakeCameraOnDead()
    {

        _mainCamera.transform.DOShakeRotation(0.1f, 1, 1, 2);


    }

}
