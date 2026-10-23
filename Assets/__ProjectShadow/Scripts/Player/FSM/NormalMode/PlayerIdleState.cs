using UnityEngine;

namespace ShadowGame
{
    public class PlayerIdleState : PlayerStateBase
    {
        public override void EnterState(NormalModeStateMachine stateMachine)
        {
            Debug.Log("[PlayerIdleState] 진입함");
        }
        public override void UpdateState(NormalModeStateMachine stateMachine)
        {
            var input = stateMachine.InputHandler;

            if (input.MoveInput == Vector2.zero)
            {
                stateMachine.Movement.StopHorizontalMovement();
                return;
            }

            // 달리기 버튼이 눌려있을 경우
            if (input.RunInput)
            {
                stateMachine.ChangeState(stateMachine.RunState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.WalkState);
            }
        }
        public override void ExitState(NormalModeStateMachine stateMachine)
        {

        }
    }
}
