using UnityEngine;

namespace ShadowGame
{
    public class PlayerRunState : PlayerStateBase
    {
        public override void EnterState(NormalModeStateMachine stateMachine)
        {
            Debug.Log("[PlayerRunState] 진입함");
            // 애니메이션 처리
        }

        public override void UpdateState(NormalModeStateMachine stateMachine)
        {
            var input = stateMachine.InputHandler;

            // 이동 입력이 사라지면 Idle로 전환
            if (input.MoveInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                return;
            }

            // 달리기 버튼을 놓았으면 Walk로 전환
            if (!input.RunInput)
            {
                stateMachine.ChangeState(stateMachine.WalkState);
                return;
            }

            // 달리기 상태를 유지
            stateMachine.Movement.Run(input.MoveInput);
        }

        public override void ExitState(NormalModeStateMachine stateMachine)
        {
            // 애니메이션 처리
        }
    }
}