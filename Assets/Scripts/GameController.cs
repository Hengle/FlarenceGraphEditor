using UnityEngine;

namespace FlarenceGraphEditor {
    public class GameController : MonoBehaviour {
        public static GameController Instance;

        public Camera MainCamera;
        
        public GameObject ConnectionPrefab;

        public Transform EditorArea;

        private void Awake() {
            Instance = this;
            MainCamera=Camera.main;
        }
        
    }
}