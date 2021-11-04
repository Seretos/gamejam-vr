using System;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class Position : MonoBehaviour
    {
        public Transform anchor;

        /*private void Start()
        {
            if (anchor == null)
                anchor = transform;
        }*/
    }
}