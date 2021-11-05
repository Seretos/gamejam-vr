using Photon.Pun;
using UnityEngine;

namespace mark1.multiplayer
{
    public class NetworkPlayer : MonoBehaviourPunCallbacks
    {
        public Transform head;
        public Transform body;
        public Transform rightHand;
        public Transform leftHand;

        public Transform networkHead;
        public Transform networkBody;
        public Transform networkRightHand;
        public Transform networkLeftHand;

        private void Update()
        {
            if (photonView.IsMine)
            {
                networkHead.gameObject.SetActive(false);
                networkBody.gameObject.SetActive(false);
                networkRightHand.gameObject.SetActive(false);
                networkLeftHand.gameObject.SetActive(false);
                
                networkHead.position = head.position;
                networkHead.rotation = head.rotation;
                networkHead.localScale = head.lossyScale;

                networkRightHand.position = rightHand.position;
                networkRightHand.rotation = rightHand.rotation;
                networkRightHand.localScale = rightHand.lossyScale;
                
                networkLeftHand.position = leftHand.position;
                networkLeftHand.rotation = leftHand.rotation;
                networkLeftHand.localScale = leftHand.lossyScale;
                
                networkBody.position = body.position;
                networkBody.localScale = body.lossyScale;
                //networkBody.rotation = body.rotation;
            }
        }

    }
}