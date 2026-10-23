using UnityEngine;

namespace ShadowGame
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(NormalModeStateMachine))]
    [RequireComponent(typeof(PlayerModeSwitch))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerMovement _movement;
        private NormalModeStateMachine _normalModeStateMachine;
        private PlayerModeSwitch _playerModeSwitch;

        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _movement = GetComponent<PlayerMovement>();
            _normalModeStateMachine = GetComponent<NormalModeStateMachine>();
            _playerModeSwitch = GetComponent<PlayerModeSwitch>();

            if (_inputHandler == null ||
                _movement == null ||
                _normalModeStateMachine == null ||
                _playerModeSwitch == null)
            {
                Debug.LogError("PlayerController 초기화에 필요한 컴포넌트가 없음", this);

                enabled = false;
                return;
            }

            // NormalModeStateMachine 에 입력 및 이동 컴포넌트 연결
            _normalModeStateMachine.Initialize(_inputHandler, _movement);

            // 모드 전환 시스템 초기화
             _playerModeSwitch.Initialize(_normalModeStateMachine);
        }
    }
}
