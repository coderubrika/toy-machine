using System.Collections;
using UnityEngine;
using WanzyeeStudio;
using UnityEngine.EventSystems;
using UltEvents;

namespace Assets.Scripts
{
    public class InputManager : BaseSingleton<InputManager>
    {
        public UltEvent<PointerEventData> OnClickBegin;
        public UltEvent<PointerEventData> OnClickEnd;

        public void ClickBegin(BaseEventData eventData)
        {
            OnClickBegin.InvokeSafe(eventData as PointerEventData);
        }

        public void ClickEnd(BaseEventData eventData)
        {
            OnClickEnd.InvokeSafe(eventData as PointerEventData);
        }
    }
}