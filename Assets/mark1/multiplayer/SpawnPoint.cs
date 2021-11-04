using System;
using mark1.world;
using UnityEngine;

namespace mark1.multiplayer
{
    [RequireComponent(typeof(Position))]
    public class SpawnPoint : UserBehaviourPunCallbacks
    {
        private Position _position;

        private void Start()
        {
            _position = GetComponent<Position>();
        }

        public void SetPlayerToPoint(Transform player)
        {
            //Debug.Log(transform.lossyScale.x);
            //player.localScale = transform.localScale;
            player.localScale = _position.anchor.lossyScale;
            player.position = _position.anchor.position;
            player.rotation = _position.anchor.rotation;
            player.parent = _position.anchor;
        }
    }
}
