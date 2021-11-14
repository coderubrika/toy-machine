using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class SimpleInteractableDetector : MonoBehaviour
    {
        [SerializeField]
        private int layerMask;

        [SerializeField]
        private float castDistance = 0.1f;

        private Interactable interactable;

        private void OnEnable()
        {
            InputManager.instance.OnClickBegin += ClickBegin;
            InputManager.instance.OnClickEnd += ClickEnd;
        }

        private void OnDisable()
        {
            InputManager.instance.OnClickBegin -= ClickBegin;
            InputManager.instance.OnClickEnd -= ClickEnd;
        }

        private void FixedUpdate()
        {
            Interactable found = null;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, castDistance, 1 << layerMask))
            {
                found = hit.collider.GetComponent<Interactable>();
            }

            if (found && !interactable)
            {
                found.Hover();
                interactable = found;
            }

            else if (!found && interactable && !interactable.Clicked)
            {
                interactable.UnHover();
                interactable = null;
            } 

            else if (found && interactable && interactable != found && !interactable.Clicked)
            {
                interactable.UnHover();
                found.Hover();
                interactable = found;
            }

            Debug.DrawRay(transform.position, transform.forward * castDistance, Color.yellow);
        }

        private void ClickBegin(PointerEventData eventData)
        {
            if (interactable) interactable.ClickBegin(eventData, transform);
        }

        private void ClickEnd(PointerEventData eventData)
        {
            if (interactable) interactable.ClickEnd(eventData, transform);
        }
    }
}