using Unity.Robotics.UrdfImporter.Control;
using UnityEngine;

public class MyController : MonoBehaviour
{
    [SerializeField] private ControlType control = ControlType.PositionControl;
    [SerializeField] private float stiffness;
    [SerializeField] private float damping;
    [SerializeField] private float forceLimit;
    [SerializeField] private float speed = 5f; // Units: degree/s
    private ArticulationBody[] _articulationChain;
    private int _previousIndex;
    private string _selectedJoint;
    private int _selectedIndex;

    public float GetSpeed() => speed;

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

    private void SetSelectedJointIndex(int index)
    {
        if (_articulationChain.Length > 0)
        {
            _selectedIndex = (index + _articulationChain.Length) % _articulationChain.Length;
        }
    }

    private void Update()
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

        if (_articulationChain[jointIndex].TryGetComponent(out MyJointController current))
        {
            if (_previousIndex != jointIndex)
            {
                if (_articulationChain[_previousIndex].TryGetComponent(out MyJointController previous))
                {
                    previous.SetRotationDirection(RotationDirection.None);
                    _previousIndex = jointIndex;
                }
                else
                {
                    Debug.LogError("Previous joint is null", this);
                }
            }

            if (current.GetControlType() != control)
            {
                UpdateControlType(current);
            }
        }
        else
        {
            Debug.LogError("Current joint is null", this);
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