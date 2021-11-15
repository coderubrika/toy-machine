using System.Collections;
using UltEvents;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputToSignal3 : MonoBehaviour
    {
        [SerializeField]
        private float treshhold = 0.1f;

        private bool inputPermission = true;
        public bool InputPermission
        {
            set
            {
                inputPermission = value;
            }

            get
            {
                return inputPermission;
            }
        }

        public UltEvent<Signal3> OnInputX, OnInputY, OnInputZ;

        private void Awake()
        {
            treshhold = Mathf.Abs(treshhold);
        }

        private Signal3 GetSignalByValue(float value)
        {
            if (value > treshhold)
            {
                return Signal3.Positive;
            }

            else if (value < -treshhold)
            {
                return Signal3.Negative;
            }

            else return Signal3.None;
        }

        public void SetInput(Vector3 input)
        {
            if (!InputPermission)
            {
                OnInputX.InvokeSafe(Signal3.None);
                OnInputY.InvokeSafe(Signal3.None);
                OnInputZ.InvokeSafe(Signal3.None);
            }

            else
            {
                OnInputX.InvokeSafe(GetSignalByValue(input.x));
                OnInputY.InvokeSafe(GetSignalByValue(input.y));
                OnInputZ.InvokeSafe(GetSignalByValue(input.z));
            }
            
        }
    }
}