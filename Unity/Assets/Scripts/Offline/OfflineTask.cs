using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Offline
{
    public abstract class OfflineTask : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] private bool autoStart;
        [SerializeField] private bool loopExecution;

        [Header("References")] 
        [SerializeField] private MyController controller;

        [Header("Status")] 
        [SerializeField] private State state;
        [SerializeField] private List<Instruction> instructions;

        [Header("Debug")] 
        [SerializeField] private GizmosSetting gizmosSettings;
        [SerializeField] private bool verbose;
        [SerializeField] private bool isValid;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            if (autoStart)
            {
                Execute();
            }
        }

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

        protected void Wait(float milliseconds)
        {
        }

        protected void AttachTool()
        {
        }

        protected void Action(UnityEvent unityEvent, bool value)
        {
            if (value)
            {
                unityEvent.Invoke();
            }
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

        private void Init()
        {
            Gizmos.color = gizmosSettings.color;
        }
    }

    public enum State
    {
        Idle,
        Busy
    }

    [Serializable]
    public struct GizmosSetting
    {
        public GizmoType type;
        public Color color;
        public float size;
    }
}