using TMPro;
using UnityEngine;

namespace FlarenceGraphEditor.EditorUi.InfoPanel {
    public class DebugInfoPanelController : MonoBehaviour {
        public static DebugInfoPanelController Instance;

#pragma warning disable 649
        [SerializeField] private TMP_Text TextBox;
#pragma warning restore 649

        private void Awake() {
            Instance = this;
        }

        public void ShowMessage(string message) {
            TextBox.text = message;
        }
    }
}