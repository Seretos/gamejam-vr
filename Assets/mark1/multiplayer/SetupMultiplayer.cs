using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace mark1.multiplayer
{
    public class SetupMultiplayer : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                Debug.Log("connecting to server...");
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("joining room...");
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            roomOptions.IsVisible = true;
            roomOptions.IsOpen = true;
            roomOptions.PublishUserId = true;
            PhotonNetwork.JoinOrCreateRoom("dev", roomOptions, TypedLobby.Default);
        }
    }
}
