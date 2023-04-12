using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Root.Scripts.Catch
{
    [RequireComponent(typeof(CatchEvent))]
    public class Catch : MonoBehaviour
    {
        [HideInInspector] public CatchEvent CatchEvent;
        [field: SerializeField] public Transform CatchPlace { get; private set; }
        

        private void Awake()
        {
            CatchEvent = GetComponent<CatchEvent>();
        }

        private void OnEnable()
        {
            CatchEvent.OnCatch += CatchEvent_OnCatch;
        }

        private void OnDisable()
        {
            CatchEvent.OnCatch -= CatchEvent_OnCatch;
        }

        private void CatchEvent_OnCatch(CatchEvent catchEvent, CatchEventArgs catchEventArgs)
        {
            Catching(catchEventArgs.CatchableItem);
        }

        private void Catching(CatchableItem catchableItem)
        {
            catchableItem.transform.SetParent(CatchPlace);
            catchableItem.Rigidbody2D.isKinematic = true;
            catchableItem.BoxCollider2D.enabled = false;
            catchableItem.transform.localPosition = Vector3.zero;
        }
    }
}