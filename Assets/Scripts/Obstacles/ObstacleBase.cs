using DG.Tweening;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleBase : MonoBehaviour
    {
        [SerializeField] protected Transform obstacleTransform;
        [SerializeField] protected Transform startValue;
        [SerializeField] protected Transform endValue;
        [SerializeField] protected float stepDuration;
    }
}
