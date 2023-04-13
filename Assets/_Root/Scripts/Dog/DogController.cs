using System;
using UnityEngine;

namespace _Root.Scripts.Dog
{
    [RequireComponent(typeof(DogView))]
    public class DogController : MonoBehaviour
    {
        private DogView _dogView;
        private float _speed;
        private int _currentPoint = 0;
        private float _stoppingDistance = 0.2f;

        private void Awake()
        {
            _dogView = GetComponent<DogView>();
            _speed = _dogView.Speed;
        }

        private void Start()
        {
            MovementLogic();
        }

        private void Update()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            Debug.Log($"Current {_currentPoint}");
            Debug.Log(Mathf.Abs(Mathf.Abs(_dogView.transform.position.x) - Mathf.Abs(_dogView.PatrolsPoint[_currentPoint].position.x)));
            if (Mathf.Abs(Mathf.Abs(_dogView.transform.position.x) - Mathf.Abs(_dogView.PatrolsPoint[_currentPoint].position.x)) <= _stoppingDistance)
            {
                CalculateRoute();
                _currentPoint = (_currentPoint + 1) % _dogView.PatrolsPoint.Length;
            }
            _dogView.MovementByVelocityEvent.CallMovementEvent(_speed);
        }

        private void CalculateRoute()
        {
            
            if (Vector3.Dot(_dogView.transform.position, _dogView.PatrolsPoint[_currentPoint].position) > 0)
            {
                _speed *= -1;
                _dogView.transform.localScale = new Vector3(-_dogView.transform.localScale.x, 1, 1);
            }
        }
    }
}