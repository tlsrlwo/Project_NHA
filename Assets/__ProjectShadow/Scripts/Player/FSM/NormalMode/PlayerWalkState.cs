using UnityEngine;

namespace ShadowGame
{
    public class PlayerWalkState : PlayerStateBase
    {
        public override void EnterState(NormalModeStateMachine stateMachine)
        {
            Debug.Log("[PlayerWalkState] 진입함");
        }
        public override void UpdateState(NormalModeStateMachine stateMachine)
        {
            var input = stateMachine.InputHandler;

            // 입력이 0일때
            if (input.MoveInput == Vector2.zero)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                return;
            }
            // 달리기 버튼이 눌렸을 경우
            if (input.RunInput)
            {
                stateMachine.ChangeState(stateMachine.RunState);
                return;
            }

            // 상태 전환 조건이 없을 경우 계속 걷기
            stateMachine.Movement.Walk(input.MoveInput);

        }
        public override void ExitState(NormalModeStateMachine stateMachine)
        {

        }
    }
}
