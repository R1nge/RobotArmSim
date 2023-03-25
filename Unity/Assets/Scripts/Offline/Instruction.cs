using System;
using UnityEngine;

namespace Offline
{
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
}