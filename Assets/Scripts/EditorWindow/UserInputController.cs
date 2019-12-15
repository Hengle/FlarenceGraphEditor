using FlarenceGraphEditor.EditorWindow.Nodes;
using FlarenceGraphEditor.EditorWindow.Nodes.GraphNodeLinkPoints;
using UnityEngine;

namespace FlarenceGraphEditor.EditorWindow {
    public class UserInputController : MonoBehaviour {
        public static UserInputController Instance;

        private void Awake() {
            Instance = this;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                if (hit) {
                    if (hit.transform.CompareTag(TransformTags.GraphNodeLinkPoint)) {
                        hit.transform.GetComponent<GraphNodeLinkPoint>().StartNewConnection();
                    }
                    if (hit.transform.CompareTag(TransformTags.GraphNode)) {
                        hit.transform.GetComponent<GraphNodeController>().StartDragging();;
                    }
                }
                
                
            }
        }
    }
}