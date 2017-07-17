﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public bool lockCursor;
    float yaw;
    float pitch;

    public float mouseSensitivity = 10;
    public Transform target;
    public float dstFromTarget = 2;

    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    bool mouseEnable;

    void Start()
    {
        mouseEnable = true;
        if (lockCursor)
        {
          Cursor.lockState = CursorLockMode.Locked;
          Cursor.visible = false;
        }
    }

    void LateUpdate () {
        if (mouseEnable)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;

        
            transform.position = target.position - transform.forward * dstFromTarget;
        }
	}

    public void EnableMouse()
    {
        mouseEnable = true;
    }

    public void DisableMouse()
    {
        mouseEnable = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LockTheCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
