using System;
using UnityEngine;

namespace _Root.Scripts.Movement
{
    public class JumpChecker : MonoBehaviour
    {
        public event Action<bool> OnTriggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggered?.Invoke(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggered?.Invoke(false);
        }
    }
}