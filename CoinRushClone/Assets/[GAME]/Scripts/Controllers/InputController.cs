using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{


    public static Action<float> OnTouch;

    [SerializeField] private FloatingJoystick _floatingJoystick;

    

    // Update is called once per frame
    void Update()
    {

        ProcessTouch();
        
    }



    private void ProcessTouch()
    {
        float xValueOfJoystick = GetJoystickXValue();

        if (Input.GetMouseButton(0))
        {
           OnTouch?.Invoke(xValueOfJoystick);

        }





    }       


    
    private float GetJoystickXValue()
    {
        return _floatingJoystick.Direction.x;
        
    }







}
