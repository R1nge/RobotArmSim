//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class GraspMsg : Message
    {
        public const string k_RosMessageName = "moveit_msgs/Grasp";
        public override string RosMessageName => k_RosMessageName;

        //  This message contains a description of a grasp that would be used
        //  with a particular end-effector to grasp an object, including how to
        //  approach it, grip it, etc.  This message does not contain any
        //  information about a "grasp point" (a position ON the object).
        //  Whatever generates this message should have already combined
        //  information about grasp points with information about the geometry
        //  of the end-effector to compute the grasp_pose in this message.
        //  A name for this grasp
        public string id;
        //  The internal posture of the hand for the pre-grasp
        //  only positions are used
        public Trajectory.JointTrajectoryMsg pre_grasp_posture;
        //  The internal posture of the hand for the grasp
        //  positions and efforts are used
        public Trajectory.JointTrajectoryMsg grasp_posture;
        //  The position of the end-effector for the grasp.  This is the pose of
        //  the "parent_link" of the end-effector, not actually the pose of any
        //  link *in* the end-effector.  Typically this would be the pose of the
        //  most distal wrist link before the hand (end-effector) links began.
        public Geometry.PoseStampedMsg grasp_pose;
        //  The estimated probability of success for this grasp, or some other
        //  measure of how "good" it is.
        public double grasp_quality;
        //  The approach direction to take before picking an object
        public GripperTranslationMsg pre_grasp_approach;
        //  The retreat direction to take after a grasp has been completed (object is attached)
        public GripperTranslationMsg post_grasp_retreat;
        //  The retreat motion to perform when releasing the object; this information
        //  is not necessary for the grasp itself, but when releasing the object,
        //  the information will be necessary. The grasp used to perform a pickup
        //  is returned as part of the result, so this information is available for 
        //  later use.
        public GripperTranslationMsg post_place_retreat;
        //  the maximum contact force to use while grasping (<=0 to disable)
        public float max_contact_force;
        //  an optional list of obstacles that we have semantic information about
        //  and that can be touched/pushed/moved in the course of grasping
        public string[] allowed_touch_objects;

        public GraspMsg()
        {
            this.id = "";
            this.pre_grasp_posture = new Trajectory.JointTrajectoryMsg();
            this.grasp_posture = new Trajectory.JointTrajectoryMsg();
            this.grasp_pose = new Geometry.PoseStampedMsg();
            this.grasp_quality = 0.0;
            this.pre_grasp_approach = new GripperTranslationMsg();
            this.post_grasp_retreat = new GripperTranslationMsg();
            this.post_place_retreat = new GripperTranslationMsg();
            this.max_contact_force = 0.0f;
            this.allowed_touch_objects = new string[0];
        }

        public GraspMsg(string id, Trajectory.JointTrajectoryMsg pre_grasp_posture, Trajectory.JointTrajectoryMsg grasp_posture, Geometry.PoseStampedMsg grasp_pose, double grasp_quality, GripperTranslationMsg pre_grasp_approach, GripperTranslationMsg post_grasp_retreat, GripperTranslationMsg post_place_retreat, float max_contact_force, string[] allowed_touch_objects)
        {
            this.id = id;
            this.pre_grasp_posture = pre_grasp_posture;
            this.grasp_posture = grasp_posture;
            this.grasp_pose = grasp_pose;
            this.grasp_quality = grasp_quality;
            this.pre_grasp_approach = pre_grasp_approach;
            this.post_grasp_retreat = post_grasp_retreat;
            this.post_place_retreat = post_place_retreat;
            this.max_contact_force = max_contact_force;
            this.allowed_touch_objects = allowed_touch_objects;
        }

        public static GraspMsg Deserialize(MessageDeserializer deserializer) => new GraspMsg(deserializer);

        private GraspMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.id);
            this.pre_grasp_posture = Trajectory.JointTrajectoryMsg.Deserialize(deserializer);
            this.grasp_posture = Trajectory.JointTrajectoryMsg.Deserialize(deserializer);
            this.grasp_pose = Geometry.PoseStampedMsg.Deserialize(deserializer);
            deserializer.Read(out this.grasp_quality);
            this.pre_grasp_approach = GripperTranslationMsg.Deserialize(deserializer);
            this.post_grasp_retreat = GripperTranslationMsg.Deserialize(deserializer);
            this.post_place_retreat = GripperTranslationMsg.Deserialize(deserializer);
            deserializer.Read(out this.max_contact_force);
            deserializer.Read(out this.allowed_touch_objects, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.id);
            serializer.Write(this.pre_grasp_posture);
            serializer.Write(this.grasp_posture);
            serializer.Write(this.grasp_pose);
            serializer.Write(this.grasp_quality);
            serializer.Write(this.pre_grasp_approach);
            serializer.Write(this.post_grasp_retreat);
            serializer.Write(this.post_place_retreat);
            serializer.Write(this.max_contact_force);
            serializer.WriteLength(this.allowed_touch_objects);
            serializer.Write(this.allowed_touch_objects);
        }

        public override string ToString()
        {
            return "GraspMsg: " +
            "\nid: " + id.ToString() +
            "\npre_grasp_posture: " + pre_grasp_posture.ToString() +
            "\ngrasp_posture: " + grasp_posture.ToString() +
            "\ngrasp_pose: " + grasp_pose.ToString() +
            "\ngrasp_quality: " + grasp_quality.ToString() +
            "\npre_grasp_approach: " + pre_grasp_approach.ToString() +
            "\npost_grasp_retreat: " + post_grasp_retreat.ToString() +
            "\npost_place_retreat: " + post_place_retreat.ToString() +
            "\nmax_contact_force: " + max_contact_force.ToString() +
            "\nallowed_touch_objects: " + System.String.Join(", ", allowed_touch_objects.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}