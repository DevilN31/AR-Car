using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nati.Input
{
    public class TouchInputController : MonoBehaviour
    {
        [SerializeField]
        protected static float _DirectionX;
        [SerializeField]
         protected static float _DirectionY;

        public static Action<ClickableButtonType,bool> OnPressed;

        private void OnEnable()
        {
            ResetAxis();
            
        }

        private void OnDisable()
        {
            ResetAxis();

        }

        public static float GetAxis(Axis axis)
        {
            switch (axis)
            {
                case Axis.Verticle: return _DirectionY;

                case Axis.Horizontal: return _DirectionX;
                default: return 0;
            }
        }

        public static bool GetButtonPressed(ClickableButtonType clickableButton)
        {
            switch (clickableButton)
            {
                case ClickableButtonType.Fire: return true;
                case ClickableButtonType.Jump: return true;
                default: return false;
            }
        }

        void ResetAxis()
        {
            _DirectionX = 0;
            _DirectionY = 0;
        }
        
    }

    public enum MovementDirection
    {
        None,
       Positive,
       Negative
    }

    public enum Axis
    {
        Verticle,
        Horizontal
    }

    public enum ClickableButtonType
    {
        Fire,
        Jump
    }
}
