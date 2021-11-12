using System.Collections;
using UnityEngine;
using UltEvents;

namespace Assets.Scripts
{
    public class TriggerEvents : MonoBehaviour
    {
        public UltEvent<Collider> OnTriggerEnterEvent;
        public UltEvent<Collider> OnTriggerExitEvent;
        public UltEvent<Collider> OnTriggerStayEvent;


        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent.InvokeSafe(other);
        }
        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent.InvokeSafe(other);
        }
        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayEvent.InvokeSafe(other);
        }
    }
}