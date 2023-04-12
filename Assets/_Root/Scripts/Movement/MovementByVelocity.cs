using System;
using UnityEngine;

namespace _Root.Scripts.Movement
{
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [RequireComponent(typeof(Rigidbody2D))]
    [DisallowMultipleComponent]
    public class MovementByVelocity : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private MovementByVelocityEvent _movementByVelocityEvent;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _movementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        }

        private void OnEnable()
        {
            _movementByVelocityEvent.OnMovement += MovementByVelocityEventOnMovementByVelocity;
        }

        private void OnDisable()
        {
            _movementByVelocityEvent.OnMovement -= MovementByVelocityEventOnMovementByVelocity;
        }

        private void MovementByVelocityEventOnMovementByVelocity(MovementByVelocityEvent movementByVelocityEvent, MovementEventArgs movementEventArgs)
        {
            Move(movementEventArgs.Speed);
        }

        private void Move(float speed)
        {
            var rigidbody2DVelocity = _rigidbody2D.velocity;
            rigidbody2DVelocity.x = speed;
            _rigidbody2D.velocity = rigidbody2DVelocity;
        }
    }
}