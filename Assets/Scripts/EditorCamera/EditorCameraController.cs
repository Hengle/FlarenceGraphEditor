using System;
using Cinemachine;
using FLLib.UnityDependent.GoKitAddons.SafeGoKit;
using UnityEngine;

namespace FlarenceGraphEditor.EditorCamera {
    public class EditorCameraController : MonoBehaviour {

        public static EditorCameraController Instance;

#pragma warning disable 649
        
        [SerializeField] private GameObject CameraTarget;
        
        [SerializeField] private CinemachineVirtualCamera CinemachineVirtualCamera;
        
#pragma warning restore 649

        private float ZoomSpeedMultiplier = 2;
        private float ZoomMin = 10;
        private float ZoomMax = 160;
        
        private void Awake() {
            Instance = this;
            CinemachineVirtualCamera.m_Lens.OrthographicSize = 45;
        }

        public void ChangeZoom(float amount) {
            var size = CinemachineVirtualCamera.m_Lens.OrthographicSize;

            amount *= ZoomSpeedMultiplier;

            if (size + amount > ZoomMax) {
                size = ZoomMax;
            }else if (size + amount < ZoomMin) {
                size = ZoomMin;
            } else {
                size += amount;
            }

            CinemachineVirtualCamera.m_Lens.OrthographicSize = size;
        }

        public void JumpToMouse() {
            var targetLocation=GameController.Instance.MainCamera
                                .ScreenToWorldPoint(Input.mousePosition);
            targetLocation.z = 0;
            CameraTarget.transform.position = targetLocation;
        }
        
    }
}