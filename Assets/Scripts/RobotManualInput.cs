using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManualInput : MonoBehaviour
{
    public GameObject robot;
    [SerializeField] private RobotController robotController;


    void Update()
    {
        for (int i = 0; i < robotController.joints.Length; i++)
        {
            float inputVal = Input.GetAxis(robotController.joints[i].inputAxis);
            if (Mathf.Abs(inputVal) > 0)
            {
                RotationDirection direction = GetRotationDirection(inputVal);
                robotController.RotateJoint(i, direction);
                return;
            }
        }

        robotController.StopAllJointRotations();
    }


    // HELPERS

    static RotationDirection GetRotationDirection(float inputVal)
    {
        if (inputVal > 0)
        {
            return RotationDirection.Positive;
        }

        if (inputVal < 0)
        {
            return RotationDirection.Negative;
        }

        return RotationDirection.None;
    }
}