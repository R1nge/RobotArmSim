using Unity.Robotics.UrdfImporter.Control;
using UnityEngine;

public class MyController : MonoBehaviour
{
    private ArticulationBody[] _articulationChain;
    private int _previousIndex;
    private string _selectedJoint;
    private int _selectedIndex;

    public ControlType control = ControlType.PositionControl;
    public float stiffness;
    public float damping;
    public float forceLimit;
    public float speed = 5f; // Units: degree/s

    private void Start()
    {
        _previousIndex = _selectedIndex = 1;
        gameObject.AddComponent<FKRobot>();
        _articulationChain = GetComponentsInChildren<ArticulationBody>();
        int dynamicValue = 10;
        foreach (ArticulationBody joint in _articulationChain)
        {
            joint.gameObject.AddComponent<MyJointController>();
            joint.jointFriction = dynamicValue;
            joint.angularDamping = dynamicValue;
            ArticulationDrive currentDrive = joint.xDrive;
            currentDrive.forceLimit = forceLimit;
            joint.xDrive = currentDrive;
        }
    }

    void SetSelectedJointIndex(int index)
    {
        if (_articulationChain.Length > 0)
        {
            _selectedIndex = (index + _articulationChain.Length) % _articulationChain.Length;
        }
    }

    void Update()
    {
        SetSelectedJointIndex(_selectedIndex); // to make sure it is in the valid range
        UpdateDirection(_selectedIndex);
    }


    /// <summary>
    /// Sets the direction of movement of the joint on every update
    /// </summary>
    /// <param name="jointIndex">Index of the link selected in the Articulation Chain</param>
    private void UpdateDirection(int jointIndex)
    {
        if (jointIndex < 0 || jointIndex >= _articulationChain.Length)
        {
            return;
        }

        MyJointController current = _articulationChain[jointIndex].GetComponent<MyJointController>();
        if (_previousIndex != jointIndex)
        {
            MyJointController previous = _articulationChain[_previousIndex].GetComponent<MyJointController>();
            previous.SetRotationDirection(RotationDirection.None);
            _previousIndex = jointIndex;
        }

        if (current.GetControlType() != control)
        {
            UpdateControlType(current);
        }
    }

    public void UpdateControlType(MyJointController myJoint)
    {
        myJoint.SetControlType(control);
        if (control == ControlType.PositionControl)
        {
            ArticulationDrive drive = myJoint.GetJoint().xDrive;
            drive.stiffness = stiffness;
            drive.damping = damping;
            myJoint.GetJoint().xDrive = drive;
        }
    }
}