using System;
using mark1.multiplayer;
using mark1.state;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(SpawnPoint))]
    public class Checkpoint : MonoBehaviour
    {
        public GameState gameState;
        private SpawnPoint _spawnPoint;

        private void Start()
        {
            _spawnPoint = GetComponent<SpawnPoint>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                gameState.lastSpawnPoint = _spawnPoint;
            }
        }
    }
}