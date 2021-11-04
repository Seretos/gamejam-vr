using System.Collections.Generic;
using UnityEngine;

namespace mark1.state
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerState[] states;
        public enum PlayerStateType
        {
            Start,Game,Died
        }

        private Dictionary<PlayerStateType, PlayerState> _dictionary = new Dictionary<PlayerStateType, PlayerState>();
        private PlayerState _activeState;

        private void Start()
        {
            foreach (PlayerState playerState in states)
            {
                playerState.InitState(this);

                if (_dictionary.ContainsKey(playerState.type))
                {
                    Debug.LogWarning($"The key <b>{playerState.type}</b> already exists in the menu dictionary!");
                    
                    continue;
                }
                _dictionary.Add(playerState.type, playerState);
            }

            foreach (PlayerStateType playerStateType in _dictionary.Keys)
            {
                _dictionary[playerStateType].gameObject.SetActive(false);
            }
            
            SetActiveState(PlayerStateType.Start);
        }

        public void SetActiveState(PlayerStateType newState)
        {
            if (!_dictionary.ContainsKey(newState))
            {
                Debug.LogWarning($"The key <b>{newState}</b> doesn't exist so you can't activate the menu!");

                return;
            }
            
            if (_activeState != null)
            {
                _activeState.gameObject.SetActive(false);
            }
            
            _activeState = _dictionary[newState];
            
            Debug.Log($"switch to {newState} state");
            
            _activeState.gameObject.SetActive(true);
        }
    }
}