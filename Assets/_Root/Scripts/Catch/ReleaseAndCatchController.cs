using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Root.Scripts.Catch
{
    [RequireComponent(typeof(CatchEvent))]
    [RequireComponent(typeof(Catch))]
    [RequireComponent(typeof(ReleaseEvent))]
    [RequireComponent(typeof(Release))]
    public class ReleaseAndCatchController : MonoBehaviour
    {
        [field: SerializeField] public BoxCollider2D CatchCheck { get; private set; }
        [HideInInspector] public CatchEvent CatchEvent;
        [HideInInspector] public ReleaseEvent ReleaseEvent;
        private bool _isAlreadyCatched = false;
        private CatchableItem _currentCatchedItem;

        private void Awake()
        {
            CatchEvent = GetComponent<CatchEvent>();
            ReleaseEvent = GetComponent<ReleaseEvent>();
        }


        public void TryCatchingItem()
        {
            if (IsFoundSomethingCatchable(out var catchableItem) && !_isAlreadyCatched)
            {
                CatchItem(catchableItem);
            }
            else
            {
                ReleaseItem(_currentCatchedItem);
            }
        }

        private void CatchItem(CatchableItem catchableItem)
        {
            CatchEvent.CallCatchEvent(catchableItem);
            _isAlreadyCatched = true;
            _currentCatchedItem = catchableItem;
        }
        
        
        private bool IsFoundSomethingCatchable(out CatchableItem catchableItem)
        {
            List<Collider2D> collider2Ds = new List<Collider2D>();
            CatchCheck.GetContacts(collider2Ds);
            Dictionary<float, CatchableItem> catchableItems = new Dictionary<float, CatchableItem>();
            if (collider2Ds.Count != 0)
            {
                float minDistance = float.MaxValue;
                foreach (var catchItem in collider2Ds)
                {
                    var catchItemComponent = catchItem.GetComponent<CatchableItem>();
                    if (catchItemComponent != null)
                    {
                        var distance = Vector3.Distance(transform.position, catchItem.gameObject.transform.position);
                        catchableItems.Add(distance, catchItemComponent);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                        }
                    }
                }

                if (catchableItems.Count > 0)
                {
                    catchableItem = catchableItems[minDistance];
                    return true;
                }
            }

            catchableItem = null;
            return false;
        }
        
        private void ReleaseItem(CatchableItem currentCatchedItem)
        {
            ReleaseEvent.CallReleaseEvent(currentCatchedItem);
            _currentCatchedItem = null;
            _isAlreadyCatched = false;
        }
    }
}