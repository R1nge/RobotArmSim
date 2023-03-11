using UnityEngine;

public class RobotManualInput : MonoBehaviour
{
    [SerializeField] private RobotController robotController;
    
    private void Update()
    {
        for (int i = 0; i < robotController.GetJoints().Length; i++)
        {
            float inputVal = Input.GetAxis(robotController.GetJoints()[i].inputAxis);
            if (Mathf.Abs(inputVal) > 0)
            {
                RotationDirection direction = GetRotationDirection(inputVal);
                robotController.RotateJoint(i, direction);
                return;
            }
        }

        robotController.StopAllJointRotations();
    }

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