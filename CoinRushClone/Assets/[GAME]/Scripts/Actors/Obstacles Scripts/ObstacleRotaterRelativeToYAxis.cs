using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotaterRelativeToYAxis : MonoBehaviour
{
 private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {

        _transform.Rotate(-1*Vector3.forward*Speeds.ObstacleRotateSpeedRelativeToYAxis*Time.deltaTime, Space.Self );
        

    }


}
