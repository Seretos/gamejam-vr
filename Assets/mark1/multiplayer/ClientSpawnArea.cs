using System;
using mark1.world;
using Photon.Pun;
using Photon.Realtime;

namespace mark1.multiplayer
{
    public class ClientSpawnArea : UserBehaviourPunCallbacks, IPunOwnershipCallbacks
    {
        private ClientSpawnPoint[] _spawnPoints;

        private void Start()
        {
            _spawnPoints = GetComponentsInChildren<ClientSpawnPoint>();
        }

        [PunRPC]
        public override void SetUserRPC(string user)
        {
            if (user == PhotonNetwork.AuthValues.UserId)
            {
                TakeSpawnAreaOwnership();
            }
            base.SetUserRPC(user);
        }

        private void TakeSpawnAreaOwnership()
        {
            photonView.RequestOwnership();
            foreach (Position position in GetComponentsInChildren<Position>())
            {
                if (position.GetComponent<PhotonView>())
                {
                    position.GetComponent<PhotonView>().RequestOwnership();
                }
            }
        }
        
        public SpawnPoint GenerateSpawnPoint()
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                spawnPoint.SetUser("");
            }

            Random r = new Random();
            int rInt = r.Next(0, _spawnPoints.Length);
            _spawnPoints[rInt].SetUser(PhotonNetwork.AuthValues.UserId);
            return _spawnPoints[rInt];
        }
        
        public void OnOwnershipRequest(PhotonView targetView, Photon.Realtime.Player requestingPlayer)
        {
            if (targetView != photonView)
                return;
            photonView.TransferOwnership(requestingPlayer);
        }

        public void OnOwnershipTransfered(PhotonView targetView, Photon.Realtime.Player previousOwner)
        {
            if (targetView != photonView)
                return;
        }

        public void OnOwnershipTransferFailed(PhotonView targetView, Photon.Realtime.Player senderOfFailedRequest)
        {
        }
    }
}