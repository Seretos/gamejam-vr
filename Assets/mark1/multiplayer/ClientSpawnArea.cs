using System;
using mark1.world;
using Photon.Pun;
using Photon.Realtime;

namespace mark1.multiplayer
{
    public class ClientSpawnArea : UserBehaviourPunCallbacks
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
                photonView.RequestOwnership();
            }
            base.SetUserRPC(user);
        }

        private void TakeSpawnAreaOwnership()
        {
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
    }
}