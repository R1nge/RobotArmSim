using System;
using UnityEngine;

namespace Offline
{
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
}