using Photon.Pun;
using UnityEngine;

namespace mark1.multiplayer
{
    [RequireComponent(typeof(PhotonView))]
    public class UserBehaviourPunCallbacks : MonoBehaviourPunCallbacks
    {
        public string _userId = "";

        [PunRPC]
        public void SetUserRPC(string user)
        {
            _userId = user;
        }

        public virtual void SetUser(string user)
        {
            if (PhotonNetwork.IsConnected)
            {
                photonView.RPC("SetUserRPC", RpcTarget.AllBuffered, user);
            }
            else
            {
                _userId = user;
            }
        }

        public string GetUser()
        {
            return _userId;
        }
    }
}