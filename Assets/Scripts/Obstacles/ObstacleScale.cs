using System;
using DG.Tweening;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleScale : ObstacleBase
    {
        private void Start()
        {
            obstacleTransform.localScale = startValue.localScale;
            obstacleTransform.DOScale(endValue.localScale,stepDuration).SetLoops(-1,LoopType.Yoyo);
        }
    }
}
