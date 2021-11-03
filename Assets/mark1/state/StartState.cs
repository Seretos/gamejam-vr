using System;

namespace mark1.state
{
    public class StartState : PlayerState
    {
        public override void InitState(PlayerController c)
        {
            base.InitState(c);
            type = PlayerController.PlayerStateType.Start;
        }

        private void OnEnable()
        {
            controller.transform.position = transform.position;
        }
    }
}