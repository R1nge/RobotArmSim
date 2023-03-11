//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class ToolFeedback : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/Tool";
        public override string RosMessageName => k_RosMessageName;

        //  feedback
        public int progression;

        public ToolFeedback()
        {
            this.progression = 0;
        }

        public ToolFeedback(int progression)
        {
            this.progression = progression;
        }

        public static ToolFeedback Deserialize(MessageDeserializer deserializer) => new ToolFeedback(deserializer);

        private ToolFeedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.progression);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.progression);
        }

        public override string ToString()
        {
            return "ToolFeedback: " +
            "\nprogression: " + progression.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}
