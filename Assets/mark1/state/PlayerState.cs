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

        public void JumpToGameState()
        {
            HostSpawnPoint host = FindObjectOfType<HostSpawnPoint>();
            if (host.GetUser() == PhotonNetwork.AuthValues.UserId)
            {
                Debug.Log("jump into game as host");
                host.SetPlayerToPoint(controller.transform);
            }
            else
            {
                Debug.Log("jump into game as client");
                foreach (ClientSpawnArea clientSpawnArea in FindObjectsOfType<ClientSpawnArea>())
                {
                    if (clientSpawnArea.GetUser() == PhotonNetwork.AuthValues.UserId)
                    {
                        SpawnPoint point = clientSpawnArea.GenerateSpawnPoint();
                        point.SetPlayerToPoint(controller.transform);
                        break;
                    }
                }
            }
        }
    }
}