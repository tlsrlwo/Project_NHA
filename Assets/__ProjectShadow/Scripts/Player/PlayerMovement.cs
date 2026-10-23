using UnityEngine;

namespace ShadowGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("움직임 관련 설정")]
        [SerializeField] private float _walkSpeed = 1f;
        [SerializeField] private float _runSpeed = 5f;

        [SerializeField] private float _gravity = -9.81f;

        // 현재 수직 속도
        private float _verticalVelocity;

        [Header("Component")]
        private CharacterController _cController;
        PlayerInputHandler _pInput;

        public float CurrentMoveSpeed { get; private set; }

        void Awake()
        {
            _cController = GetComponent<CharacterController>();
        }

        public void Walk(Vector2 input)
        {
            Move(input, _walkSpeed);
        }

        public void Run(Vector2 input)
        {
            Move(input, _runSpeed);
        }

        public void StopHorizontalMovement()
        {
            Move(Vector2.zero, 0f);
        }

        private void Move(Vector2 input, float speed)
        {
            Vector3 dir = new Vector3(input.x, 0f, input.y);

            // 대각선 입력이 직선 입력보다 빨라지는 것을 방지
            dir = Vector3.ClampMagnitude(dir, 1f);

            // 입력이 있으면 선택된 속도, 없으면 0
            CurrentMoveSpeed = dir.sqrMagnitude > 0f ? speed : 0f;

            //Debug.Log($"[PlayerMovement] CurrentMoveSpeed = {speed}");

            // 바닥에 붙어있게 하기
            if (_cController.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }
            else
            {
                // 중력 적용
                _verticalVelocity += _gravity * Time.deltaTime;
            }

            // 최종 이동속도 = 수평이동 + 수직이동 
            Vector3 velocity = dir * speed + Vector3.up * _verticalVelocity;

            // 실제 이동 부분
            _cController.Move(velocity * Time.deltaTime);
        }
    }
}
