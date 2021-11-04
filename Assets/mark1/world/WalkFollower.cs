using PathCreation;
using UnityEngine;

namespace mark1.world
{
    public class WalkFollower : PathFollower
    {
        private Vector3 _localDiff;
        private void Start()
        {
            _localDiff = _position.transform.position - _position.anchor.position;
        }
        
        protected override void SetAnchorPosition()
        {
            base.SetAnchorPosition();
            Vector3 startPos = _path.path.GetPointAtDistance(0.0f, EndOfPathInstruction.Stop);
            Vector3 posDiff = _position.transform.position - startPos;
            _position.anchor.position = _position.transform.position - _localDiff + posDiff;
        }
    }
}