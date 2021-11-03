using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(BoxCollider))]
    public class Player : MonoBehaviour
    {
        public Transform bodyPosition;
        
        private BoxCollider _collider;

        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            Vector3 centerPos = transform.InverseTransformPoint(bodyPosition.position);
            centerPos = new Vector3(centerPos.x, 0.0f, centerPos.z);
            _collider.center = centerPos;
        }
    }
}