using System;
using UnityEngine;

namespace mark1.world
{
    public class JointCopy : MonoBehaviour
    {
        public Transform source;

        private void Update()
        {
            source.position = transform.position;
            source.rotation = transform.rotation;
            source.localScale = transform.localScale;
        }
    }
}