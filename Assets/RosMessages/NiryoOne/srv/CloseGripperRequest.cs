//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class CloseGripperRequest : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/CloseGripper";
        public override string RosMessageName => k_RosMessageName;

        public byte id;
        public short close_position;
        public short close_speed;
        public short close_hold_torque;
        public short close_max_torque;

        public CloseGripperRequest()
        {
            this.id = 0;
            this.close_position = 0;
            this.close_speed = 0;
            this.close_hold_torque = 0;
            this.close_max_torque = 0;
        }

        public CloseGripperRequest(byte id, short close_position, short close_speed, short close_hold_torque, short close_max_torque)
        {
            this.id = id;
            this.close_position = close_position;
            this.close_speed = close_speed;
            this.close_hold_torque = close_hold_torque;
            this.close_max_torque = close_max_torque;
        }

        public static CloseGripperRequest Deserialize(MessageDeserializer deserializer) => new CloseGripperRequest(deserializer);

        private CloseGripperRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.id);
            deserializer.Read(out this.close_position);
            deserializer.Read(out this.close_speed);
            deserializer.Read(out this.close_hold_torque);
            deserializer.Read(out this.close_max_torque);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.id);
            serializer.Write(this.close_position);
            serializer.Write(this.close_speed);
            serializer.Write(this.close_hold_torque);
            serializer.Write(this.close_max_torque);
        }

        public override string ToString()
        {
            return "CloseGripperRequest: " +
            "\nid: " + id.ToString() +
            "\nclose_position: " + close_position.ToString() +
            "\nclose_speed: " + close_speed.ToString() +
            "\nclose_hold_torque: " + close_hold_torque.ToString() +
            "\nclose_max_torque: " + close_max_torque.ToString();
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
