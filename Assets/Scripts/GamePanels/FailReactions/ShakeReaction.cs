using DG.Tweening;
using UnityEngine;
using WordAlgorithm.Interfaces;

namespace WordAlgorithm.GamePanels.FailReactions
{
    public class ShakeReaction : IFailReaction
    {
        private Transform _transform;
        public ShakeReaction(Transform transform)
        {
            _transform = transform;
        }

        public void Play()
        {
            _transform.DOShakeRotation(1f, Vector3.one * 2f);
        }
    }
}