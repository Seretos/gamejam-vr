using System;
using UnityEngine;
using UnityEngine.Events;

namespace mark1.world
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayAreaCenter : MonoBehaviour
    {
        //public PlayArea playArea;
        public UnityEvent playerEnterCenter;
        public UnityEvent playerLeaveCenter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                playerEnterCenter.Invoke();
                //playArea.playerEnterCenter.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Player>())
            {
                playerLeaveCenter.Invoke();
                //playArea.playerLeaveCenter.Invoke();
            }
        }
    }
}