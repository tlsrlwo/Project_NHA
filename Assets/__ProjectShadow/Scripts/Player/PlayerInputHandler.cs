using UnityEngine;
using UnityEngine.InputSystem;

namespace ShadowGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        // 방향키로부터 받은 이동 입력을 저장
        private Vector2 _moveInput;

        // 달리기 버튼을 누르고 있는지 저장
        private bool _runInput;

        public Vector2 MoveInput => _moveInput;
        public bool RunInput => _runInput;

        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
            //Debug.Log($"[Input] Move : {_moveInput}");
        }

        public void OnRun(InputValue value)
        {
            _runInput = value.isPressed;
            Debug.Log($"[Input] Run : {_runInput}");
        }
    }
}
