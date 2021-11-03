using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace mark1.multiplayer
{
    public class PlayerSpawnManager : MonoBehaviourPunCallbacks
    {
        private HostSpawnPoint _hostSpawnPoint;
        private ClientSpawnArea[] _clientSpawnAreas;

        void Start()
        {
            _hostSpawnPoint = FindObjectOfType<HostSpawnPoint>();
            _clientSpawnAreas = FindObjectsOfType<ClientSpawnArea>();
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

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            if (photonView.IsMine)
            {
                Debug.Log("client joined the room");
                FindFreeClientSpawnArea().SetUser(newPlayer.UserId);
            }
            base.OnPlayerEnteredRoom(newPlayer);
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            if (photonView.IsMine)
            {
                Debug.Log("client leaves the room");
                ClearClientSpawnArea(otherPlayer.UserId);
            }
            base.OnPlayerLeftRoom(otherPlayer);
        }

        public override void OnMasterClientSwitched(Photon.Realtime.Player newMasterClient)
        {
            base.OnMasterClientSwitched(newMasterClient);
            if (newMasterClient.UserId == PhotonNetwork.AuthValues.UserId)
            {
                Debug.Log("switched from client to host");
                _hostSpawnPoint.SetUser(PhotonNetwork.AuthValues.UserId);
                ClearClientSpawnArea(PhotonNetwork.AuthValues.UserId);
            }
        }

        private ClientSpawnArea FindFreeClientSpawnArea()
        {
            foreach (ClientSpawnArea clientSpawnArea in _clientSpawnAreas)
            {
                if (clientSpawnArea.GetUser() == "")
                {
                    return clientSpawnArea;
                }
            }
            Debug.Log("error! no free spawn area found!");
            return null;
        }

        private void ClearClientSpawnArea(string user)
        {
            foreach (ClientSpawnArea clientSpawnArea in _clientSpawnAreas)
            {
                if (clientSpawnArea.GetUser() == user)
                {
                    clientSpawnArea.SetUser("");
                }
            }
        }
    }
}
