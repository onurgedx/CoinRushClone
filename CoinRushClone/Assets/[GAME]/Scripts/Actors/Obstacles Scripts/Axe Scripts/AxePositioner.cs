using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePositioner : MonoBehaviour, IPositionable
{
    public PositionableTypeEnum Type => PositionableTypeEnum.Axe;
    public Transform GetTransform()
    {
        return transform;
    }
    public void SetPositionAndRotation(Transform _leftBoundTransform, Transform _rightBoundTransform, int indexOfPositionable, IPositionable positionable)
    {
        float xPosition ;
        float yPosition ;
        float zPosition ;
        if(positionable != null)
        {

        switch (positionable.Type)
        {
            case PositionableTypeEnum.Axe:
                xPosition = Mathf.Lerp(positionable.GetTransform().position.x, 0, 0.3f);
                break;

            default:
                if (indexOfPositionable % 2 == 0)
                {
                    xPosition = _leftBoundTransform.position.x;
                }
                else
                {
                    xPosition = _rightBoundTransform.position.x;
                }
                break;
        }

        }
        else
        {
            xPosition = _leftBoundTransform.position.x;

        }
       // xPosition = Random.Range(_leftBoundTransform.position.x, _rightBoundTransform.position.x);
        yPosition = -1;
        zPosition = indexOfPositionable * 3;

        transform.position = new Vector3(xPosition, yPosition, zPosition);

        transform.rotation =Quaternion.LookRotation(Vector3.left*transform.position.x);



    }
}
