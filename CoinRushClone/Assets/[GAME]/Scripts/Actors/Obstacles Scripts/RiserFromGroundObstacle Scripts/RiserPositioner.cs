using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiserPositioner : MonoBehaviour ,IPositionable
{
    public PositionableTypeEnum Type =>PositionableTypeEnum.Riser;

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetPositionAndRotation(Transform _leftBoundTransform, Transform _rightBoundTransform, int indexOfPositionable, IPositionable positionable)
    {
        float xPosition = Random.Range(_leftBoundTransform.position.x, _rightBoundTransform.position.x);
        float yPosition = -1;
        float zPosition = indexOfPositionable * Distances.DistanceOfLevelActors;

        transform.position = new Vector3(xPosition, yPosition, zPosition);

    }


}
