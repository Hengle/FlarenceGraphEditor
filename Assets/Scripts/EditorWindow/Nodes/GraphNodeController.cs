using FlarenceGraphEditor.EditorWindow.Nodes.GraphNodeLinkPoints;
using UnityEngine;

namespace FlarenceGraphEditor.EditorWindow.Nodes {
    public class GraphNodeController : InteractableItem {

        public override string ItemName => "Graph Node";
        
#pragma warning disable 649
        [SerializeField]private GraphNodeLinkPointController InputNodeLinkPoint;
        [SerializeField]private GraphNodeLinkPointController OutputNodeLinkPoint;
#pragma warning restore 649
        
        private bool _isDragging;
        private bool isDragging {
            get => _isDragging;
            set {
                foreach (var connection in InputNodeLinkPoint.Connections) {
                    connection.IsDragging = value;
                }
                foreach (var connection in OutputNodeLinkPoint.Connections) {
                    connection.IsDragging = value;
                }
                
                _isDragging = value;
            }
        }

        private void Update() {
            if (isDragging) {
                if (Input.GetMouseButtonUp(0)) {
                    isDragging = false;
                }
                var targetPosition=GameController.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0;
                transform.position = targetPosition;
            }
        }
        
        #region Helpers

        public void StartDragging() {
            isDragging = true;
        }

        #endregion

        #region Interactable Object Implementation

        public override void OnLeftClickDown() {
            StartDragging();
        }
        
        public override void OnCreatedFromInventory() {
            StartDragging();
        }

        #endregion

        
    }
}