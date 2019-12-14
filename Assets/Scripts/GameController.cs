using UnityEngine;

namespace FlarenceGraphEditor {
    public class GameController : MonoBehaviour {
        public static GameController Instance;

        private void Awake() {
            Instance = this;
        }
        
    }
}