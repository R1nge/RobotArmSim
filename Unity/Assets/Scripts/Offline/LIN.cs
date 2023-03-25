using System;
using UnityEngine;

namespace Offline
{
    [Serializable]
    public class LIN : Instruction
    {
        private readonly Vector3 _position;
        private readonly Quaternion _rotation;

        public LIN(Vector3 position)
        {
            _position = position;
        }

        public LIN(Quaternion rotation)
        {
            _rotation = rotation;
        }

        public override void Execute()
        {
            Debug.Log($"LIN pos: {_position}, rot: {_rotation}");
        }
    }
}