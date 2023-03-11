using Unity.Robotics.UrdfImporter.Control;
using UnityEngine;

public class MyJointController : MonoBehaviour
{
    private RotationDirection _direction;
    private ControlType _controlType;
    private MyController _controller;
    private float _speed;
    private ArticulationBody _joint;

    public void SetRotationDirection(RotationDirection newDirection) => _direction = newDirection;

    public ControlType GetControlType() => _controlType;

    public void SetControlType(ControlType controlType) => _controlType = controlType;

    public ArticulationBody GetJoint() => _joint;

    private void Start()
    {
        _direction = 0;
        _controller = GetComponentInParent<MyController>();
        _joint = GetComponent<ArticulationBody>();
        _controller.UpdateControlType(this);
        _speed = _controller.speed;
    }

    private void FixedUpdate()
    {
        _speed = _controller.speed;


        if (_joint.jointType != ArticulationJointType.FixedJoint)
        {
            if (_controlType == ControlType.PositionControl)
            {
                ArticulationDrive currentDrive = _joint.xDrive;
                float newTargetDelta = (int)_direction * Time.fixedDeltaTime * _speed;

                if (_joint.jointType == ArticulationJointType.RevoluteJoint)
                {
                    if (_joint.twistLock == ArticulationDofLock.LimitedMotion)
                    {
                        if (newTargetDelta + currentDrive.target > currentDrive.upperLimit)
                        {
                            currentDrive.target = currentDrive.upperLimit;
                        }
                        else if (newTargetDelta + currentDrive.target < currentDrive.lowerLimit)
                        {
                            currentDrive.target = currentDrive.lowerLimit;
                        }
                        else
                        {
                            currentDrive.target += newTargetDelta;
                        }
                    }
                    else
                    {
                        currentDrive.target += newTargetDelta;
                    }
                }

                else if (_joint.jointType == ArticulationJointType.PrismaticJoint)
                {
                    if (_joint.linearLockX == ArticulationDofLock.LimitedMotion)
                    {
                        if (newTargetDelta + currentDrive.target > currentDrive.upperLimit)
                        {
                            currentDrive.target = currentDrive.upperLimit;
                        }
                        else if (newTargetDelta + currentDrive.target < currentDrive.lowerLimit)
                        {
                            currentDrive.target = currentDrive.lowerLimit;
                        }
                        else
                        {
                            currentDrive.target += newTargetDelta;
                        }
                    }
                    else
                    {
                        currentDrive.target += newTargetDelta;
                    }
                }

                _joint.xDrive = currentDrive;
            }
        }
    }
}