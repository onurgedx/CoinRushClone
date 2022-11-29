using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public static class TransformExtension 
{

    public static void BounceEffect(this Transform _transform, float bounceAspect,float growDuration,float shrinkDuration)
    {

        //_transform.DOKill(true);
        //_transform.DOKill(true); // eger bu kapaliyken bozuk olursa bunu ac
        Vector3 recordedLocalScale = _transform.localScale;
        _transform.DOScale(recordedLocalScale * bounceAspect, growDuration).OnComplete(() => _transform.DOScale(recordedLocalScale, shrinkDuration));

    }
   


}
