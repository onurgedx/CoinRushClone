using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionable 
{
    public void SetPositionAndRotation(Transform _leftBoundTransform , Transform _rightBoundTransform, int indexOfPositionable , IPositionable positionable  );



    public PositionableTypeEnum Type { get;  }
    public Transform GetTransform();
}
