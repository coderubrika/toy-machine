using System.Collections;
using UltEvents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Interactable : MonoBehaviour
    {
        public UltEvent<PointerEventData, Transform> OnClickBegin;
        public UltEvent<PointerEventData, Transform> OnClickEnd;
        public UltEvent<PointerEventData, Transform> OnHover;
        public UltEvent<PointerEventData, Transform> OnUnHover;

        private bool clicked;
        public bool Clicked => clicked;
        
        private bool hovered;
        public bool Hovered => hovered;

        public void ClickBegin(PointerEventData data = null, Transform other = null)
        {
            clicked = true;
            OnClickBegin.InvokeSafe(data, other);
        }

        public void ClickEnd(PointerEventData data = null, Transform other = null)
        {
            clicked = false;
            OnClickEnd.InvokeSafe(data, other);
        }

        public void Hover(PointerEventData data = null, Transform other = null)
        {
            hovered = true;
            OnHover.InvokeSafe(data, other);
        }

        public void UnHover(PointerEventData data = null, Transform other = null)
        {
            hovered = false;
            OnUnHover.InvokeSafe(data, other);
        }
    }
}