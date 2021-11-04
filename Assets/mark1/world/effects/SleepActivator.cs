using System;
using UnityEngine;

namespace mark1.world.effects
{
    [RequireComponent(typeof(PathFollower))]
    public class SleepActivator : MonoBehaviour
    {
        public float sleep = 3.0f;
        private PathFollower _follower;
        private float _delta = 0.0f;

        private void Start()
        {
            _follower = GetComponent<PathFollower>();
        }

        private void Update()
        {
            if (!_follower.running)
            {
                _delta += Time.deltaTime;
            }

            if (_delta > sleep)
            {
                _follower.running = true;
                _delta = 0.0f;
            }
        }
    }
}