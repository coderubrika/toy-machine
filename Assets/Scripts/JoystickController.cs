using System.Collections;
using UltEvents;
using UnityEngine;

namespace Assets.Scripts
{
    public class JoystickController : MonoBehaviour
    {

        public UltEvent<Vector2> OnMove;

        public Transform topOfJoystick;

        private bool holdOn = false;

        private Transform hand;

        [SerializeField]
        private Transform costraint;

        private Quaternion revertRotation;

        [SerializeField]
        private float speedOfRevert = 10f;

        private void Awake()
        {
            revertRotation = Quaternion.LookRotation(costraint.up);
        }

        private void Update()
        {
            if (hand && holdOn)
            {

                Vector3 handInversePosition = costraint.InverseTransformPoint(hand.position);

                handInversePosition.y = Mathf.Clamp(handInversePosition.y, 0, float.PositiveInfinity);

                Vector3 lookTarget = costraint.TransformPoint(handInversePosition);

                transform.LookAt(lookTarget, transform.up);

                Vector3 topInverseByConstaint = costraint.InverseTransformPoint(topOfJoystick.position);

                OnMove.InvokeSafe(new Vector2(Mathf.Clamp(topInverseByConstaint.x, -1, 1), Mathf.Clamp(topInverseByConstaint.z, -1, 1)));
            }
          
            else
            { 
                transform.rotation = Quaternion.Slerp(transform.rotation, revertRotation, speedOfRevert * Time.deltaTime);
            }

        }

        public void Hold(Transform hand)
        {
            this.hand = hand;
            holdOn = true;
        }

        public void Relax()
        {
            this.hand = null;
            holdOn = false;
        }
    }
}