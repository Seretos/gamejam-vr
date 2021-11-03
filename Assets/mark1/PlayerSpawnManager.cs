using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace mark1
{
    public class PlayerSpawnManager : MonoBehaviourPunCallbacks
    {
        private HostSpawnPoint _hostSpawnPoint;
        private ClientSpawnPoint[] _clientSpawnPoints;

        void Start()
        {
            _hostSpawnPoint = FindObjectOfType<HostSpawnPoint>();
            _clientSpawnPoints = FindObjectsOfType<ClientSpawnPoint>();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            if (photonView.IsMine)
            {
                Debug.Log("host joined the room");
                _hostSpawnPoint.SetUser(PhotonNetwork.AuthValues.UserId);
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (photonView.IsMine)
            {
                Debug.Log("client joined the room");
                FindFreeClientSpawnPoint().SetUser(newPlayer.UserId);
            }
            base.OnPlayerEnteredRoom(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            if (photonView.IsMine)
            {
                Debug.Log("client leaves the room");
                ClearClientSpawnPoint(otherPlayer.UserId);
            }
            base.OnPlayerLeftRoom(otherPlayer);
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            base.OnMasterClientSwitched(newMasterClient);
            if (newMasterClient.UserId == PhotonNetwork.AuthValues.UserId)
            {
                Debug.Log("switched from client to host");
                _hostSpawnPoint.SetUser(PhotonNetwork.AuthValues.UserId);
                ClearClientSpawnPoint(PhotonNetwork.AuthValues.UserId);
            }
        }

        private ClientSpawnPoint FindFreeClientSpawnPoint()
        {
            foreach (ClientSpawnPoint clientSpawnPoint in _clientSpawnPoints)
            {
                if (clientSpawnPoint.GetUser() == "")
                {
                    return clientSpawnPoint;
                }
            }
            Debug.Log("error! no free spawn point found!");
            return null;
        }

        private void ClearClientSpawnPoint(string user)
        {
            foreach (ClientSpawnPoint clientSpawnPoint in _clientSpawnPoints)
            {
                if (clientSpawnPoint.GetUser() == user)
                {
                    clientSpawnPoint.SetUser("");
                }
            }
        }
    }
}
