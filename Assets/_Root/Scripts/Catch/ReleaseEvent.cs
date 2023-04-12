using System;
using UnityEngine;

namespace _Root.Scripts.Catch
{
    public class ReleaseEvent : MonoBehaviour
    {
        public event Action<ReleaseEvent, ReleaseEventArgs> OnRelease;

        public void CallReleaseEvent(CatchableItem catchableItem)
        {
            OnRelease?.Invoke(this, new ReleaseEventArgs()
            {
                CatchableItem = catchableItem
            });
        }

        public class ReleaseEventArgs : EventArgs
        {
            public CatchableItem CatchableItem;
        }
    }
}