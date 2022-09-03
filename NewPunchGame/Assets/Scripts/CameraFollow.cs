using UnityEngine;

namespace Utilities
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        public float smoothTime = 0.1f;
        private Vector3 _velocity = Vector3.zero;

        private void LateUpdate()
        {
            var desiredPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothTime);
        }
    }
}