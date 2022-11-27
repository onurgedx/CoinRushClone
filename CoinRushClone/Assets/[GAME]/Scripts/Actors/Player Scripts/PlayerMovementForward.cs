using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForward : MonoBehaviour
{


    [SerializeField] private Transform _coinTransform;


    public float PlayerSpeed = 10;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();



    }




    private void MoveForward()
    {


        transform.position += _coinTransform.forward * PlayerSpeed * Time.deltaTime;
        



    }

}
