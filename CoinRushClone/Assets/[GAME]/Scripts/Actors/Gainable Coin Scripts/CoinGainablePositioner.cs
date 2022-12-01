using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGainablePositioner : MonoBehaviour, IPositionable
{
    public PositionableTypeEnum Type { get => PositionableTypeEnum.CoinGainable; }

    public void SetPositionAndRotation(Transform _leftBoundTransform, Transform _rightBoundTransform, int indexOfPositionable, IPositionable positionable)
    {
        float xPosition = Random.Range(_leftBoundTransform.position.x, _rightBoundTransform.position.x);
        float yPosition = -1;
        float zPosition = indexOfPositionable * 5;

        transform.position = new Vector3(xPosition, yPosition, zPosition);

    }

    public Transform GetTransform()
    {
        return transform;
    }
}