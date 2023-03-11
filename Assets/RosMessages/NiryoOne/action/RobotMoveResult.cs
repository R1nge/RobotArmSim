//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class RobotMoveResult : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/RobotMove";
        public override string RosMessageName => k_RosMessageName;

        //  result
        public int status;
        public string message;

        public RobotMoveResult()
        {
            this.status = 0;
            this.message = "";
        }

        public RobotMoveResult(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public static RobotMoveResult Deserialize(MessageDeserializer deserializer) => new RobotMoveResult(deserializer);

        private RobotMoveResult(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.status);
            deserializer.Read(out this.message);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.status);
            serializer.Write(this.message);
        }

        public override string ToString()
        {
            return "RobotMoveResult: " +
            "\nstatus: " + status.ToString() +
            "\nmessage: " + message.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Result);
        }
    }
}