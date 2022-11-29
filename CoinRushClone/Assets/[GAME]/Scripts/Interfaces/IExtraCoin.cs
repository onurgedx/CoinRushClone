using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExtraCoin 
{

    public void Lose();
    public Transform GetModelTransform();
    public GameObject GetGameObject();

    public void SetExtraCoinPositionAndRotate(Transform leadTransform);


    public Transform GetReferanceFollowTransform();
   
}
