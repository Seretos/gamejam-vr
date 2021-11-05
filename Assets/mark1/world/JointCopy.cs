using System;
using Photon.Pun;
using UnityEngine;

namespace mark1.world
{
    public class JointCopy : MonoBehaviourPunCallbacks
    {
        public Transform source;

        private void Update()
        {
            if (photonView.IsMine)
            {
                source.position = transform.position;
                source.rotation = transform.rotation;
                source.localScale = transform.localScale;
            }
        }
    }
}