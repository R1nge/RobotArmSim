//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class TakePictureResponse : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/TakePicture";
        public override string RosMessageName => k_RosMessageName;

        public bool success;

        public TakePictureResponse()
        {
            this.success = false;
        }

        public TakePictureResponse(bool success)
        {
            this.success = success;
        }

        public static TakePictureResponse Deserialize(MessageDeserializer deserializer) => new TakePictureResponse(deserializer);

        private TakePictureResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.success);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.success);
        }

        public override string ToString()
        {
            return "TakePictureResponse: " +
            "\nsuccess: " + success.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}