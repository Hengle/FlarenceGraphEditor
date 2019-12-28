using System;
using FlarenceGraphEditor.EditorCamera;
using FlarenceGraphEditor.EditorWindow;
using FlarenceGraphEditor.EditorWindow.Nodes;
using FlarenceGraphEditor.EditorWindow.Nodes.GraphNodeLinkPoints;
using UnityEngine;

namespace FlarenceGraphEditor {
    public class UserInputController : MonoBehaviour {
        public static UserInputController Instance;

        private void Awake() {
            Instance = this;
        }

        private void Update() {
            
            //LMB
            if (Input.GetMouseButtonDown(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                if (hit) {
                    if (hit.transform.CompareTag(TransformTags.GraphNodeLinkPoint) || 
                        hit.transform.CompareTag(TransformTags.GraphNode) ||
                        hit.transform.CompareTag(TransformTags.InventoryEntry)) {
                        hit.transform.GetComponent<InteractableItem>().OnLeftClickDown();
                    }
                }
            }
            
            //MMB
            if (Input.GetMouseButtonDown(2)) {
                EditorCameraController.Instance.JumpToMouse();
            }
            
            //Scroll
            if (Math.Abs(Input.mouseScrollDelta.y)>0.1f) {
                EditorCameraController.Instance.ChangeZoom(-Input.mouseScrollDelta.y);
            }
        }
    }
}