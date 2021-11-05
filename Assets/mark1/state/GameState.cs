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
        private GameObject _networkPlayerInstance;
        
        public Transform head;
        public Transform body;
        public Transform rightHand;
        public Transform leftHand;

        
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

        private void OnDisable()
        {
            if (_networkPlayerInstance)
            {
                _networkPlayerInstance.SetActive(false);
            }
        }

        private void OnEnable()
        {
            if (!_networkPlayerInstance)
            {
                _networkPlayerInstance =
                    PhotonNetwork.Instantiate("generic_avatar", transform.position, transform.rotation);
                
                NetworkPlayer netPlayer = _networkPlayerInstance.GetComponent<NetworkPlayer>();
                netPlayer.head = head;
                netPlayer.body = body;
                netPlayer.rightHand = rightHand;
                netPlayer.leftHand = leftHand;

            }
            _networkPlayerInstance.SetActive(true);
            
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