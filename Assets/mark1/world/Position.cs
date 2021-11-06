using System;
using Photon.Pun;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class Position : MonoBehaviourPunCallbacks
    {
        public Transform anchor;
    }
}