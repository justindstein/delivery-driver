using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float SteerSpeed;
    [SerializeField] private float MoveSpeed;

    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const float STEER_SPEED_DIRECTION = -1f;

    private float movementInput;
    private float steerInput;

    void Start()
    {
    }

    void Update()
    {
        this.movementInput = Input.GetAxis(VERTICAL_AXIS);
        this.steerInput = Input.GetAxis(HORIZONTAL_AXIS);

        if (movementInput != 0)
        {
            //transform.Translate(new Vector3(0, (movementInput * MoveSpeed) * Time.deltaTime, 0), Space.Self);
            transform.Translate(0, movementInput * MoveSpeed * Time.deltaTime, 0);
        }

        if (steerInput != 0)
        {
            transform.Rotate(0, 0, steerInput * SteerSpeed * STEER_SPEED_DIRECTION * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {

    }
}
