using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlwaysOnGround : MonoBehaviour
{


    public Action SetPositionOnGroundEvent;
    private int _layerMaskForOnGround;
    [SerializeField] private List<int> layerNumbersThatPlayerStayOn = new List<int>();

    [SerializeField] private Transform _raycastOriginTransform;

    [SerializeField] private MeshRenderer _meshRenderer;

    private float _offSetForUp;
     
    


    private void OnEnable()
    {
         SetPositionOnGroundEvent += SetPositionOnGround;
    }
    private void OnDisable()
    {
        SetPositionOnGroundEvent -= SetPositionOnGround;
    }
    void Start()
    {

        _offSetForUp = _meshRenderer.bounds.extents.y;


        _layerMaskForOnGround = 0;
        for (int i = 0; i < layerNumbersThatPlayerStayOn.Count; i++)
        {

            _layerMaskForOnGround += (int)Mathf.Pow(2, layerNumbersThatPlayerStayOn[i]);

        }
        
       
        
        
    }

    
    void Update()
    {


        SetPositionOnGroundEvent?.Invoke();

        
    }

    private void SetPositionOnGround()
    {
        RaycastHit raycastHit;

        if(Physics.Raycast(_raycastOriginTransform.position, Vector3.down,out  raycastHit,1000, _layerMaskForOnGround))
        {
            transform.StayOnFloor(_offSetForUp, raycastHit.point);

           
            
        }



    }





}
