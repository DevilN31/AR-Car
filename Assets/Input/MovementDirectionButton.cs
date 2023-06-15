using Nati.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nati.Input
{
    public class MovementDirectionButton : TouchInputController,IPointerDownHandler,IPointerUpHandler
    {
        [SerializeField]
        Axis _Axis;
        [SerializeField]
        MovementDirection _MovementDirection;

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (_Axis)
            {
                case Axis.Verticle:
                    _DirectionY = _MovementDirection == MovementDirection.Positive ? 1 : -1; break;
                case Axis.Horizontal:
                    _DirectionX = _MovementDirection == MovementDirection.Positive ? 1 : -1; break;
            }

           // Debug.Log($"<MovementDirectionButton> Direction X {_DirectionX} Direction Y {_DirectionY}");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            switch (_Axis)
            {
                case Axis.Verticle:
                    _DirectionY = 0; break;
                case Axis.Horizontal:
                    _DirectionX = 0; break;
            }
        }

    }
}
