using UnityEngine;

namespace _Root.Scripts.Catch
{
    public class CatchableItem : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public BoxCollider2D BoxCollider2D { get; private set; }
    }
}