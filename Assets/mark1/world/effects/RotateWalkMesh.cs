using UnityEngine;

namespace mark1.world.effects
{
    public class RotateWalkMesh : MonoBehaviour
    {
        public Transform mesh;
        private Vector3 _lastPosition;
        private float _lastDirection;

        private void Start()
        {
            _lastPosition = transform.position;
            _lastDirection = transform.InverseTransformVector(_lastPosition).z;
        }

        private void Update()
        {
            if (transform.position != _lastPosition)
            {
                float distance = Vector3.Distance(_lastPosition, transform.position);
                Vector3 rel = transform.InverseTransformVector(_lastPosition);
                float dir = 1.0f;
                if (rel.z < _lastDirection)
                    dir = -1.0f;
                mesh.Rotate(new Vector3(0, 1, 0), distance * 90 * dir);
            }

            _lastDirection = transform.InverseTransformVector(_lastPosition).z;
            _lastPosition = transform.position;
        }

    }
}