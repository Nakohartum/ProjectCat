using System;
using System.Collections.Generic;
using _Root.Scripts.Catch;
using _Root.Scripts.Movement;
using Cat;
using UnityEngine;

namespace _Root.Scripts.Cat
{
    [RequireComponent(typeof(CatView))]
    [RequireComponent(typeof(ReleaseAndCatchController))]
    public class PlayerController : MonoBehaviour
    {
        private ReleaseAndCatchController _releaseAndCatchController;
        private CatView _catView;
        private float _speed;
        private float _jumpPower;

        private void Awake()
        {
            _catView = GetComponent<CatView>();
            _releaseAndCatchController = GetComponent<ReleaseAndCatchController>();
            _speed = _catView.Speed;
            _jumpPower = _catView.JumpPower;
        }

        private void Update()
        {
            MovementLogic();
            if (Input.GetKeyDown(KeyCode.F))
            {
                _releaseAndCatchController.TryCatchingItem();
            }
        }

        

        private void MovementLogic()
        {
            Move();
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        private void Jump()
        { 
            _catView.PhysicsJumpEvent.CallPhysicsJumpEvent(_jumpPower);
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            var transformLocalScale = _catView.transform.localScale;
            transformLocalScale.x = horizontal < 0? -1 : 1;
            _catView.transform.localScale = transformLocalScale;
            _catView.MovementByVelocityEvent.CallMovementEvent(horizontal * _speed);
        }
    }
}