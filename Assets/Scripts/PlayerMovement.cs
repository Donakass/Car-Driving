using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float currentSteerAngle;

    // Settings
    [SerializeField] private float motorForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = 0f; // Сбрасываем горизонтальный ввод

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                float screenWidth = Screen.width;

                // Проверяем, где произошло касание
                if (touch.position.x < screenWidth / 2)
                {
                    // Левая часть экрана - поворот влево
                    horizontalInput = -1f;
                }
                else
                {
                    // Правая часть экрана - поворот вправо
                    horizontalInput = 1f;
                }
            }
        }
    }

    private void HandleMotor()
    {
        // Устанавливаем постоянное движение вперед
        frontLeftWheelCollider.motorTorque = motorForce;
        frontRightWheelCollider.motorTorque = motorForce;
    }

    private void HandleSteering()
    {
        // Рассчитываем угол поворота
        currentSteerAngle = maxSteerAngle * horizontalInput;

        // Применяем угол поворота к передним колесам
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        // Обновляем положение и вращение колес
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}

