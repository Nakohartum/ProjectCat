using System;
using UnityEngine;

namespace _Root.Scripts.Movement
{
    [DisallowMultipleComponent]
    public class PhysicsJumpEvent : MonoBehaviour
    {
        public event Action<PhysicsJumpEvent, PhysicsJumpEventArgs> OnPhysicsJump;

        public void CallPhysicsJumpEvent(float jumpPower)
        {
            OnPhysicsJump?.Invoke(this, new PhysicsJumpEventArgs()
            {
                JumpPower = jumpPower
            });
        }
    }

    public class PhysicsJumpEventArgs : EventArgs
    {
        public float JumpPower;
    }
}