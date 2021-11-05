using System;
using Photon.Pun;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class Position : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    {
        public Transform anchor;

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