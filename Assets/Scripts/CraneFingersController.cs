using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class CraneFingersController
    {
        [SerializeField]
        private HingeJoint[] fingers;

        public float GetMaxAngle()
        {
            return fingers[0].limits.max;
        }

        public float GetMinAngle()
        {
            return fingers[0].limits.min;
        }

        public float Angle
        {
            get
            {
                return fingers[0].spring.targetPosition;
            }

            set
            {
                JointSpring spring = fingers[0].spring;
                spring.targetPosition = value;

                foreach (var finger in fingers)
                {
                    finger.spring = spring;
                }
            }
        }
    }
}