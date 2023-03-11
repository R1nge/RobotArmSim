//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class GetPositionListRequest : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/GetPositionList";
        public override string RosMessageName => k_RosMessageName;


        public GetPositionListRequest()
        {
        }
        public static GetPositionListRequest Deserialize(MessageDeserializer deserializer) => new GetPositionListRequest(deserializer);

        private GetPositionListRequest(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "GetPositionListRequest: ";
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