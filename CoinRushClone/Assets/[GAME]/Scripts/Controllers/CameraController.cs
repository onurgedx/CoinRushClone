using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    private Camera _mainCamera;

    [SerializeField] private Transform _cameraReferance;


    public float CameraSpeed = 10f;



    public Action CameraMovementEvent;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {




        CameraMovementEvent?.Invoke();



    }

    private void OnEnable()
    {
        CameraMovementEvent += ControlCameraMovement;
    }

    private void OnDisable()
    {
        CameraMovementEvent -= ControlCameraMovement;
        
    }

    private void ControlCameraMovement()
    {
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _cameraReferance.position,Time.deltaTime*CameraSpeed);
        


    }



}
