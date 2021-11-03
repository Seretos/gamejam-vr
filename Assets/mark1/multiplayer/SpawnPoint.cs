using UnityEngine;

namespace mark1.multiplayer
{
    public class SpawnPoint : UserBehaviourPunCallbacks
    {
        public void SetPlayerToPoint(Transform player)
        {
            player.localScale = transform.localScale;
            player.position = transform.position;
            player.rotation = transform.rotation;
            player.parent = transform;
        }
    }
}
