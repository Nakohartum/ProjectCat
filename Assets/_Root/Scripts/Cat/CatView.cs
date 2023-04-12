using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Scripts.Catch;
using _Root.Scripts.Movement;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cat
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [RequireComponent(typeof(MovementByVelocity))]
    [RequireComponent(typeof(PhysicsJumpEvent))]
    [RequireComponent(typeof(PhysicsJump))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CatView : MonoBehaviour
    {
        [HideInInspector] public MovementByVelocityEvent MovementByVelocityEvent;
        [HideInInspector] public PhysicsJumpEvent PhysicsJumpEvent;
        
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float JumpPower { get; private set; }
        [field: SerializeField] public JumpChecker JumpChecker { get; private set; }
        
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }

        private void Awake()
        {
            MovementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
            PhysicsJumpEvent = GetComponent<PhysicsJumpEvent>();
        }
    }
}