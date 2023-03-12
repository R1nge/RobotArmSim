using System.Collections.Generic;
using UnityEngine;

namespace Offline
{
    public class MoveTask : OfflineTask
    {
        [SerializeField] private List<int> param;

        protected override void Program()
        {
            print("EXECUTED PROGRAM");
            PTP();
            LIN();
            Move(new PTP(new Vector3(100, 0, 100))
                .SetFrame(gameObject)
                .SetSpeed(10)
                .ExternalAxis(0, 30, 0.5f)
                .ExternalAxis(1, 30, 0.5f)
            );
            Move(new LIN(new Vector3(0, 0, 0))
                .SetFrame(gameObject)
                .SetSpeed(10)
                .ExternalAxis(0, 60, 0.5f)
                .ExternalAxis(1, 60, 0.5f)
            );
        }
    }
}