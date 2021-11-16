using System.Collections;
using UltEvents;
using UnityEngine;

namespace Assets.Scripts
{
    public class CraneController : MonoBehaviour
    {
        private UltEvent OnGrabStart;
        private UltEvent OnGrabEnd;

        [SerializeField]
        private SpringJoint mount;

        [SerializeField] 
        private HingeJoint[] fingers;

        public void Grab()
        {

        }

        private void FixedUpdate()
        {
            // опустить руку
            // сжать клешки
            // поднять руку

            // тут проще разделить это на несколько классов и использовать их по отдельности
        }
    }
}