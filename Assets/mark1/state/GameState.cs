using System;
using mark1.multiplayer;
using Photon.Pun;
using UnityEngine;
using NetworkPlayer = mark1.multiplayer.NetworkPlayer;

namespace mark1.state
{
    public class GameState : PlayerState
    {
        public SpawnPoint lastSpawnPoint;

        public override void InitState(PlayerController c)
        {
            base.InitState(c);
            type = PlayerController.PlayerStateType.Game;
        }

        private void Update()
        {
            if (controller.transform.parent == null && !PhotonNetwork.IsMasterClient)
            {
                controller.SetActiveState(PlayerController.PlayerStateType.Died);
            }
        }

        private void OnEnable()
        {
            if (!lastSpawnPoint)
            {
                HostSpawnPoint host = FindObjectOfType<HostSpawnPoint>();
                if (host.GetUser() == PhotonNetwork.AuthValues.UserId)
                {
                    Debug.Log("jump into game as host");
                    lastSpawnPoint = host;
                }
                else
                {
                    Debug.Log("jump into game as client");
                    foreach (ClientSpawnArea clientSpawnArea in FindObjectsOfType<ClientSpawnArea>())
                    {
                        if (clientSpawnArea.GetUser() == PhotonNetwork.AuthValues.UserId)
                        {
                            SpawnPoint point = clientSpawnArea.GenerateSpawnPoint();
                            lastSpawnPoint = point;
                            break;
                        }
                    }
                }
            }
            
            lastSpawnPoint.SetPlayerToPoint(controller.transform);
        }
    }
}