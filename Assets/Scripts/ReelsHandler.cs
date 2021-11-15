using System.Collections;
using UnityEngine;
using Assets.Scripts.Serializable.SencentiveFields;

namespace Assets.Scripts
{
    public class ReelsHandler : MonoBehaviour
    {
        [SerializeField]
        private SnapAxis axis;

        private SencentiveSignal signal;

        private Vector3 axisCut, minPosition, maxPosition;

        [SerializeField]
        private ConfigurableJoint reels;

        [SerializeField]
        private float minScalarPosition = -1, maxScalarPosition = 1;

        [SerializeField]
        private float moveSpeed = 1f;

        public void SetSignal (Signal3 signal)
        {
            this.signal.Set(signal);
        }

        private Vector3 GetAxisCutVector(SnapAxis axis)
        {
            switch (axis)
            {
                case SnapAxis.X:
                {
                    return Vector3.right;
                }

                case SnapAxis.Y:
                {
                    return Vector3.up;
                }

                case SnapAxis.Z:
                {
                    return Vector3.forward;
                }

                default:
                {
                    return Vector3.zero;
                }
            }
        }        

        private void Move()
        {
            if (signal.Get() == Signal3.Negative)
            {
                reels.targetPosition = Vector3.MoveTowards(reels.targetPosition, minPosition, moveSpeed * Time.deltaTime);
            }

            else if (signal.Get() == Signal3.Positive)
            {
                reels.targetPosition = Vector3.MoveTowards(reels.targetPosition, maxPosition, moveSpeed * Time.deltaTime);
            }
        }

        private void Awake()
        {
            signal = new SencentiveSignal();

            axisCut = GetAxisCutVector(axis);

            minPosition = axisCut * minScalarPosition;
            maxPosition = axisCut * maxScalarPosition;
        }

        private void FixedUpdate()
        {
            Move();

            signal.Set(Signal3.None);
        }
    }
}