using System;
using UnityEngine;

namespace _Root.Scripts.Catch
{
    public class CatchEvent : MonoBehaviour
    {
        public event Action<CatchEvent, CatchEventArgs> OnCatch;

        public void CallCatchEvent(CatchableItem catchableItem)
        {
            OnCatch?.Invoke(this, new CatchEventArgs()
            {
                CatchableItem = catchableItem
            });
        }
    }

    public class CatchEventArgs : EventArgs
    {
        public CatchableItem CatchableItem;
    }
}