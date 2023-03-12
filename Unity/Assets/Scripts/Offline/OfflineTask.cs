using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Offline
{
    public abstract class OfflineTask : MonoBehaviour
    {
        [Header("Settings")] [SerializeField] private bool autoStart;
        [SerializeField] private bool loopExecution;

        [Header("References")] [SerializeField]
        private MyController controller;

        [Header("Status")] [SerializeField] private State state;
        [SerializeField] private List<Instruction> instructions;

        [Header("Debug")] [SerializeField] private GizmoType gizmosSettings;
        [SerializeField] private bool verbose;
        [SerializeField] private bool isValid;

        protected abstract void Program();

        protected void PTP()
        {
            print("PTP");
        }

        protected void LIN()
        {
            print("LIN");
        }

        protected void Move(Instruction instruction)
        {
            instruction.Execute();
        }

        public void Compile()
        {
            //instructions.Add(instruction);
            print("Compile");
        }

        public void Execute()
        {
            Program();
        }

        public void Stop()
        {
            print("Stop");
        }
    }

    public enum State
    {
        Idle,
        Busy
    }

    [Serializable]
    public class Instruction
    {
        protected GameObject Frame;
        protected float Speed;

        public Instruction SetFrame(GameObject frame)
        {
            Frame = frame;
            return this;
        }

        public Instruction SetSpeed(float speed)
        {
            Speed = speed;
            return this;
        }

        public Instruction ExternalAxis(int index, int value, float speed)
        {
            return this;
        }

        public virtual void Execute()
        {
        }
    }

    [Serializable]
    public class PTP : Instruction
    {
        private readonly Vector3 _position;


        public PTP(Vector3 position)
        {
            _position = position;
        }

        public override void Execute()
        {
            Debug.Log($"PTP {_position}");
        }
    }

    [Serializable]
    public class LIN : Instruction
    {
        private readonly Vector3 _position;

        public LIN(Vector3 position)
        {
            _position = position;
        }

        public override void Execute()
        {
            Debug.Log($"LIN {_position}");
        }
    }
}