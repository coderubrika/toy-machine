using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class JoystickController : MonoBehaviour
    {

        public Transform topOfJoystick;

        [SerializeField]
        private float forwardBackwardTilt = 0;
        private float prevFBT = 0;

        [SerializeField]
        private float sideToSideTilt = 0;
        private float prevSST = 0;

        private void Update()
        {
            forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;

            if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
            {
                forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
                
                if (prevFBT != forwardBackwardTilt)
                {
                    prevFBT = forwardBackwardTilt;
                    Debug.LogFormat("Backward {0}", forwardBackwardTilt);
                }
                
            }

            else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
            {
                if (prevFBT != forwardBackwardTilt)
                {
                    prevFBT = forwardBackwardTilt;
                    Debug.LogFormat("Forward {0}", forwardBackwardTilt);
                }
            }

            sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;

            if (sideToSideTilt < 355 && sideToSideTilt > 290)
            {
                sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);

                if (prevSST != sideToSideTilt)
                {
                    prevSST = sideToSideTilt;
                    Debug.LogFormat("Right {0}", sideToSideTilt);
                }
            }

            else if (sideToSideTilt > 5 && sideToSideTilt < 74)
            {
                if (prevSST != sideToSideTilt)
                {
                    prevSST = sideToSideTilt;
                    Debug.LogFormat("Left {0}", sideToSideTilt);
                }
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transform.LookAt(other.transform.position, transform.up);
            }
        }
    }
}