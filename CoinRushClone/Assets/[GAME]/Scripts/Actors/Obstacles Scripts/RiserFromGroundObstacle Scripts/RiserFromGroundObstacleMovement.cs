using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiserFromGroundObstacleMovement : MonoBehaviour
{

    public float HighAmount = 3f;
    public float Speed = 10;
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;

        Speed = Random.Range(Speed * 0.5f, Speed);
        
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3 (_transform.position.x, Mathf.PingPong(Time.time*Speed, HighAmount),_transform.position.z);

        
    }
}
