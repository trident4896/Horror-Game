using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExample : MonoBehaviour
{
    public float closedAngle = 0;
    public float openedAngle = 90;
    public float doorSwingSmoothingTime = 0.5f;
    public float doorSwingMaxSpeed = 90;

    private float targetAngle;
    private float currentAngle;
    private float currentAngularVelocity;

    void Update()
    {
        if (DoorWasInteractedWith())
            ToggleAngle();

        UpdateAngle();
        UpdateRotation();
    }

    static bool DoorWasInteractedWith()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    void ToggleAngle()
    {
        if (targetAngle == openedAngle)
            targetAngle = closedAngle;
        else
            targetAngle = openedAngle;
    }

    void UpdateAngle()
    {
        currentAngle = Mathf.SmoothDamp(currentAngle,
                                         targetAngle,
                                         ref currentAngularVelocity,
                                         doorSwingSmoothingTime,
                                         doorSwingMaxSpeed);
    }

    void UpdateRotation()
    {
        transform.localRotation = Quaternion.AngleAxis(currentAngle, Vector3.up);
    }
}
