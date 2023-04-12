using System;
using UnityEngine;

namespace _Root.Scripts.Movement
{
    
    [DisallowMultipleComponent]
    public class MovementByVelocityEvent : MonoBehaviour
    {
        public event Action<MovementByVelocityEvent, MovementEventArgs> OnMovement;

        public void CallMovementEvent(float speed)
        {
            OnMovement?.Invoke(this, new MovementEventArgs()
            {
                Speed = speed
            });
        }
    }

    public class MovementEventArgs : EventArgs
    {
        public float Speed;
    }
}