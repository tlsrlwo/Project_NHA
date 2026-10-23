using UnityEngine;

namespace ShadowGame
{
    public class NormalModeStateMachine : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _movement;

        public PlayerInputHandler InputHandler => _inputHandler;
        public PlayerMovement Movement => _movement;

        public PlayerStateBase CurrentState { get; private set; }

        // 각 플레이어 상태 생성        
        private PlayerIdleState _idleState;
        private PlayerWalkState _walkState;
        private PlayerRunState _runState;

        public PlayerIdleState IdleState => _idleState;
        public PlayerWalkState WalkState => _walkState;
        public PlayerRunState RunState => _runState;
        

        public void Initialize(PlayerInputHandler inputHandler, PlayerMovement movement)
        {
            if (inputHandler == null || movement == null)
            {
                Debug.LogError("NormalModeStateMachine 에 필요한 참조가 없습니다", this);

                enabled = false;
                return;
            }

            _inputHandler = inputHandler;
            _movement = movement;

            // 상태 인스턴스를 생성            
            _idleState = new PlayerIdleState();
            _walkState = new PlayerWalkState();
            _runState = new PlayerRunState();

            // 초기 상태를 Idle 로 설정
            ChangeState(_idleState);            
        }

        private void Update()
        {
            CurrentState?.UpdateState(this);
        }

        public void ChangeState(PlayerStateBase nextState)
        {
            // 유효하지 않은 상태거나, 현재 상태와 같다면 전환하지 않음
            if (nextState == null || nextState == CurrentState)
            {
                return;
            }

            /* Debug.Log(
                $"[FSM] {CurrentState?.GetType().Name ?? "None"}" +
                $" -> {nextState?.GetType().Name}"
            ); */

            // 기존 상태를 우선 종료 처리함
            CurrentState?.ExitState(this);

            // 다음 상태로 변환
            CurrentState = nextState;

            // 변환된 상태에서 진입 함수 실행
            CurrentState?.EnterState(this);
        }
    }
}
