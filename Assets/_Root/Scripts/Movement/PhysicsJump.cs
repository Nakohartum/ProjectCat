using System;
using UnityEngine;

namespace _Root.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PhysicsJumpEvent))]
    [DisallowMultipleComponent]
    public class PhysicsJump : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private PhysicsJumpEvent _physicsJumpEvent;
        private JumpChecker _jumpChecker;
        private bool _isAllowedToJump = false;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _physicsJumpEvent = GetComponent<PhysicsJumpEvent>();
            _jumpChecker = GetComponentInChildren<JumpChecker>();
        }

        private void OnEnable()
        {
            _physicsJumpEvent.OnPhysicsJump += PhysicsJumpEvent_OnPhysicsJump;
            _jumpChecker.OnTriggered += JumpChecker_OnTriggered;
        }

        private void OnDisable()
        {
            _physicsJumpEvent.OnPhysicsJump -= PhysicsJumpEvent_OnPhysicsJump;
            _jumpChecker.OnTriggered -= JumpChecker_OnTriggered;
        }

        private void JumpChecker_OnTriggered(bool value)
        {
            _isAllowedToJump = value;
        }
        
        private void PhysicsJumpEvent_OnPhysicsJump(PhysicsJumpEvent physicsJumpEvent, PhysicsJumpEventArgs physicsJumpEventArgs)
        {
            Jump(physicsJumpEventArgs.JumpPower);
        }

        private void Jump(float jumpPower)
        {
            if (!_isAllowedToJump)
            {
                return;
            }
            _rigidbody2D.AddForce(Vector2.up * Mathf.Sqrt(jumpPower * -2f * Physics2D.gravity.y), ForceMode2D.Impulse);
        }
    }
}