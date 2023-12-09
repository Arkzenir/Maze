using System;
using DG.Tweening;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleMove : ObstacleBase
    {
        private void Start()
        {
            obstacleTransform.localPosition = startValue.localPosition;
            obstacleTransform.DOLocalMove(endValue.localPosition, stepDuration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
