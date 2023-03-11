//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Moveit
{
    [Serializable]
    public class PlanningOptionsMsg : Message
    {
        public const string k_RosMessageName = "moveit_msgs/PlanningOptions";
        public override string RosMessageName => k_RosMessageName;

        //  The diff to consider for the planning scene (optional)
        public PlanningSceneMsg planning_scene_diff;
        //  If this flag is set to true, the action
        //  returns an executable plan in the response but does not attempt execution  
        public bool plan_only;
        //  If this flag is set to true, the action of planning &
        //  executing is allowed to look around  (move sensors) if
        //  it seems that not enough information is available about
        //  the environment
        public bool look_around;
        //  If this value is positive, the action of planning & executing
        //  is allowed to look around for a maximum number of attempts;
        //  If the value is left as 0, the default value is used, as set
        //  with dynamic_reconfigure
        public int look_around_attempts;
        //  If set and if look_around is true, this value is used as
        //  the maximum cost allowed for a path to be considered executable.
        //  If the cost of a path is higher than this value, more sensing or 
        //  a new plan needed. If left as 0.0 but look_around is true, then 
        //  the default value set via dynamic_reconfigure is used
        public double max_safe_execution_cost;
        //  If the plan becomes invalidated during execution, it is possible to have
        //  that plan recomputed and execution restarted. This flag enables this
        //  functionality 
        public bool replan;
        //  The maximum number of replanning attempts 
        public int replan_attempts;
        //  The amount of time to wait in between replanning attempts (in seconds)
        public double replan_delay;

        public PlanningOptionsMsg()
        {
            this.planning_scene_diff = new PlanningSceneMsg();
            this.plan_only = false;
            this.look_around = false;
            this.look_around_attempts = 0;
            this.max_safe_execution_cost = 0.0;
            this.replan = false;
            this.replan_attempts = 0;
            this.replan_delay = 0.0;
        }

        public PlanningOptionsMsg(PlanningSceneMsg planning_scene_diff, bool plan_only, bool look_around, int look_around_attempts, double max_safe_execution_cost, bool replan, int replan_attempts, double replan_delay)
        {
            this.planning_scene_diff = planning_scene_diff;
            this.plan_only = plan_only;
            this.look_around = look_around;
            this.look_around_attempts = look_around_attempts;
            this.max_safe_execution_cost = max_safe_execution_cost;
            this.replan = replan;
            this.replan_attempts = replan_attempts;
            this.replan_delay = replan_delay;
        }

        public static PlanningOptionsMsg Deserialize(MessageDeserializer deserializer) => new PlanningOptionsMsg(deserializer);

        private PlanningOptionsMsg(MessageDeserializer deserializer)
        {
            this.planning_scene_diff = PlanningSceneMsg.Deserialize(deserializer);
            deserializer.Read(out this.plan_only);
            deserializer.Read(out this.look_around);
            deserializer.Read(out this.look_around_attempts);
            deserializer.Read(out this.max_safe_execution_cost);
            deserializer.Read(out this.replan);
            deserializer.Read(out this.replan_attempts);
            deserializer.Read(out this.replan_delay);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.planning_scene_diff);
            serializer.Write(this.plan_only);
            serializer.Write(this.look_around);
            serializer.Write(this.look_around_attempts);
            serializer.Write(this.max_safe_execution_cost);
            serializer.Write(this.replan);
            serializer.Write(this.replan_attempts);
            serializer.Write(this.replan_delay);
        }

        public override string ToString()
        {
            return "PlanningOptionsMsg: " +
            "\nplanning_scene_diff: " + planning_scene_diff.ToString() +
            "\nplan_only: " + plan_only.ToString() +
            "\nlook_around: " + look_around.ToString() +
            "\nlook_around_attempts: " + look_around_attempts.ToString() +
            "\nmax_safe_execution_cost: " + max_safe_execution_cost.ToString() +
            "\nreplan: " + replan.ToString() +
            "\nreplan_attempts: " + replan_attempts.ToString() +
            "\nreplan_delay: " + replan_delay.ToString();
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
