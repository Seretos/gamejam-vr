using System;
using UnityEngine;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayAreaCenter : MonoBehaviour
    {
        public PlayArea playArea;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                playArea.playerEnterCenter.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                playArea.playerLeaveCenter.Invoke();
            }
        }
    }
}