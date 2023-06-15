using Nati.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField]
    float _AccelerateSpeed = 1000;
    [SerializeField]
    float _BreakForce = 3000;
    [SerializeField] 
    float _maxSteerAngle = 30;
    float _currentBreakForce;


   [SerializeField]WheelCollider _FrontLeftWheel;
   [SerializeField]WheelCollider _FrontRightWheel;
   [SerializeField]WheelCollider _RearLeftWheel;
   [SerializeField]WheelCollider _RearRightWheel;
    [SerializeField] Transform _FrontLeftWheelMesh;
    [SerializeField] Transform _FrontRightWheelMesh;
    [SerializeField] Transform _RearLeftWheelMesh;
    [SerializeField] Transform _RearRightWheelMesh;


    float _horizontalInput;
    float _verticalInput;
    Rigidbody _rig;
    bool _isBreaking = false;
   public bool _isAccelerating = false;
    private float _currentSteerAngle;

    private void Start()
    {
        _rig= GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if(transform.position.y <= -3)
        {
            Destroy(gameObject);
        }

        GetInput();
     
        AnimateWheels();
    }

    private void LateUpdate()
    {
        HandleMotor();
        HandleSteering();
    }


    private void GetInput()
    {
        /*
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
        */

        _horizontalInput = TouchInputController.GetAxis(Axis.Horizontal);
        _verticalInput = TouchInputController.GetAxis(Axis.Verticle);

        // _isAccelerating = TouchInputController.GetButtonPressed(ClickableButtonType.Fire);
    }

    private void HandleMotor()
    {
        _FrontLeftWheel.motorTorque = _AccelerateSpeed * _verticalInput;
        _FrontRightWheel.motorTorque = _AccelerateSpeed * _verticalInput;

        _currentBreakForce = _verticalInput == 0 ? _BreakForce : 0f;
      
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        _FrontRightWheel.brakeTorque = _currentBreakForce;
        _FrontLeftWheel.brakeTorque = _currentBreakForce;
        _RearLeftWheel.brakeTorque = _currentBreakForce;
        _RearRightWheel.brakeTorque = _currentBreakForce;
    }

    private void HandleSteering()
    {
        _currentSteerAngle = _maxSteerAngle * _horizontalInput;
        _FrontRightWheel.steerAngle = _currentSteerAngle;
        _FrontLeftWheel.steerAngle = _currentSteerAngle;
    }

    void Accelerate(ClickableButtonType clickableButtonType,bool isPressed)
    {
        if (clickableButtonType != ClickableButtonType.Fire)
            return;
        if(isPressed)
        {
            _isAccelerating= true;
        }
        else
            _isAccelerating= false;
    }

    void Break(ClickableButtonType clickableButtonType, bool isPressed)
    {
        if (clickableButtonType != ClickableButtonType.Jump)
            return;
        if (isPressed)
        {
            _isBreaking = true;
        }
        else
            _isBreaking = false;
    }

    void UpdateWheel(Transform wheelTrans,WheelCollider wheelCollider)
    {
        Quaternion rotation;
        Vector3 position;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTrans.position = position;
        wheelTrans.rotation = rotation;
    }

    void AnimateWheels()
    {
        UpdateWheel(_FrontLeftWheelMesh, _FrontLeftWheel);
        UpdateWheel(_FrontRightWheelMesh, _FrontRightWheel);
        UpdateWheel(_RearLeftWheelMesh, _RearLeftWheel);
        UpdateWheel(_RearRightWheelMesh, _RearRightWheel);
    }    

}
