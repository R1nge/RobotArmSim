//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class GetWorkspaceRatioRequest : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/GetWorkspaceRatio";
        public override string RosMessageName => k_RosMessageName;

        public string workspace;

        public GetWorkspaceRatioRequest()
        {
            this.workspace = "";
        }

        public GetWorkspaceRatioRequest(string workspace)
        {
            this.workspace = workspace;
        }

        public static GetWorkspaceRatioRequest Deserialize(MessageDeserializer deserializer) => new GetWorkspaceRatioRequest(deserializer);

        private GetWorkspaceRatioRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.workspace);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.workspace);
        }

        public override string ToString()
        {
            return "GetWorkspaceRatioRequest: " +
            "\nworkspace: " + workspace.ToString();
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