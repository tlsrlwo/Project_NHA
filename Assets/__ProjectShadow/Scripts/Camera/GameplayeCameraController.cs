using UnityEngine;
using Unity.Cinemachine;

namespace ShadowGame
{
    [RequireComponent(typeof(CinemachineCamera))]
    public class GameplayeCameraController : MonoBehaviour
    {
        [Header("Camera")]
        private CinemachineCamera _camera;

        private void Awake()
        {
            if (!TryGetComponent(out _camera))
            {
                Debug.LogError("[GameplayeCameraController] Cinemachine 이 없습니다.", this);
            }

            enabled = false;
        }


        public void SetTarget(Transform target)
        {
            if (_camera == null)
            {
                Debug.LogError("[GameplayeCameraController] There is no camera reference", this);
                return;
            }
            
            
        }
    }
}
