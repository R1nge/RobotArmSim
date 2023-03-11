//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.NiryoOne
{
    [Serializable]
    public class GetSequenceListResponse : Message
    {
        public const string k_RosMessageName = "niryo_one_msgs/GetSequenceList";
        public override string RosMessageName => k_RosMessageName;

        public SequenceMsg[] sequences;

        public GetSequenceListResponse()
        {
            this.sequences = new SequenceMsg[0];
        }

        public GetSequenceListResponse(SequenceMsg[] sequences)
        {
            this.sequences = sequences;
        }

        public static GetSequenceListResponse Deserialize(MessageDeserializer deserializer) => new GetSequenceListResponse(deserializer);

        private GetSequenceListResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.sequences, SequenceMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.WriteLength(this.sequences);
            serializer.Write(this.sequences);
        }

        public override string ToString()
        {
            return "GetSequenceListResponse: " +
            "\nsequences: " + System.String.Join(", ", sequences.ToList());
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
