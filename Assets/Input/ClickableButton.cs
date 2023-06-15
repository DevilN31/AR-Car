using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nati.Input
{
    public class ClickableButton : TouchInputController, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        ClickableButtonType _ClickableButtonType;

        public void OnPointerDown(PointerEventData eventData)
        {
            TouchInputController.OnPressed?.Invoke(_ClickableButtonType,true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            TouchInputController.OnPressed?.Invoke(_ClickableButtonType, false);

        }
    }
}
