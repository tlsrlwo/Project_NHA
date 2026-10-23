using UnityEngine;

namespace ShadowGame
{
    public class PlayerModeSwitch : MonoBehaviour
    {
        private NormalModeStateMachine _normalModeStateMachine;

        // PlayerController가 초기화할 때 호출
        public void Initialize(NormalModeStateMachine normalModeStateMachine)
        {
            if (normalModeStateMachine == null)
            {
                Debug.LogError("NormalModeStateMachine 참조가 없습니다.", this);

                enabled = false;
                return;
            }

            _normalModeStateMachine = normalModeStateMachine;

            // 현재 기본 상태만 있기 때문
            SwitchToNormalMode();
        }

        public void SwitchToNormalMode()
        {
            if (_normalModeStateMachine == null)
                return;

            _normalModeStateMachine.enabled = true;
        }
    }
}
