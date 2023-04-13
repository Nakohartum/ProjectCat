using System;
using _Root.Scripts.Movement;
using UnityEngine;

namespace _Root.Scripts.Dog
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MovementByVelocityEvent))]
    [RequireComponent(typeof(MovementByVelocity))]
    public class DogView : MonoBehaviour
    {
        [HideInInspector] public MovementByVelocityEvent MovementByVelocityEvent;
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Transform[] PatrolsPoint { get; private set; }

        private void Awake()
        {
            MovementByVelocityEvent = GetComponent<MovementByVelocityEvent>();
        }
    }
}