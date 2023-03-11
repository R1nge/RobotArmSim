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

    public float GetSpeed() => speed;

    private void Start()
    {
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