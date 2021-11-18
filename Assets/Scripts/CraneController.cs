using System.Collections;
using UltEvents;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class CraneController : MonoBehaviour
    {
        public UltEvent OnGrabStart;
        public UltEvent OnGrabEnd;

        [SerializeField]
        private float moveSpeed = 1f, rotateSpeed = 30f, interval = 0.3f;

        [SerializeField]
        private float upDistance = 0, downDistance = 0.5f;

        [SerializeField]
        private SpringJoint mount;

        [SerializeField]
        private CraneFingersController craneFingers;

        private Sequence sequence;

        private void Awake()
        {
            SetupSequence();
        }

        private void SetupSequence()
        {
            sequence = DOTween.Sequence().
                SetUpdate(UpdateType.Fixed, true).
                SetAutoKill(false).
                OnPlay( ()=> OnGrabStart.InvokeSafe() ).
                OnComplete( ()=> OnGrabEnd.InvokeSafe() );

            sequence.
                Append(DOTween.To(() => mount.minDistance, value => mount.minDistance = value, downDistance, moveSpeed)).
                AppendInterval(interval).
                Append(DOTween.To(() => craneFingers.Angle, (val) => craneFingers.Angle = val, craneFingers.GetMaxAngle(), rotateSpeed)).
                Append(DOTween.To(() => mount.minDistance, value => mount.minDistance = value, upDistance, moveSpeed)).
                Append(DOTween.To(() => craneFingers.Angle, (val) => craneFingers.Angle = val, craneFingers.GetMinAngle(), rotateSpeed)).
                Complete();
        }

        public void Grab()
        {
            if(!sequence.IsPlaying()) sequence.Restart();
        }
    }
}