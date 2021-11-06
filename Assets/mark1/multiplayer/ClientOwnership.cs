using Photon.Pun;

namespace mark1.multiplayer
{
    public class ClientOwnership : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
    {
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