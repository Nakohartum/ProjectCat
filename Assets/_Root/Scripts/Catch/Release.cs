using UnityEngine;

namespace _Root.Scripts.Catch
{
    [RequireComponent(typeof(ReleaseEvent))]
    public class Release : MonoBehaviour
    {
        [HideInInspector] public ReleaseEvent ReleaseEvent;
        

        private void Awake()
        {
            ReleaseEvent = GetComponent<ReleaseEvent>();
        }

        private void OnEnable()
        {
            ReleaseEvent.OnRelease += ReleaseEvent_OnRelease;
        }

        private void OnDisable()
        {
            ReleaseEvent.OnRelease -= ReleaseEvent_OnRelease;
        }

        private void ReleaseEvent_OnRelease(ReleaseEvent releaseEvent, ReleaseEvent.ReleaseEventArgs releaseEventArgs)
        {
            Releasing(releaseEventArgs.CatchableItem);
        }

        private void Releasing(CatchableItem catchableItem)
        {
            catchableItem.transform.SetParent(null);
            catchableItem.Rigidbody2D.isKinematic = false;
            catchableItem.BoxCollider2D.enabled = true;
        }
    }
}