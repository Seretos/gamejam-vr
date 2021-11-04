using System;
using mark1.multiplayer;
using Photon.Pun;
using UnityEngine;

namespace mark1.state
{
    public class PlayerState : MonoBehaviour
    {
        public PlayerController.PlayerStateType type { get; protected set; }
        protected PlayerController controller;

        public virtual void InitState(PlayerController c)
        {
            controller = c;
        }
    }
}