using UnityEngine;

namespace FlarenceGraphEditor.EditorWindow.Nodes.GraphNodeLinkPoints {
    public class InterNodeConnection : MonoBehaviour {

        #region Draw Coordinates

        private (Vector2 start, Vector2 end) Ends;

        #endregion
        
        private GraphNodeLinkPoint InputNode;
        
        private GraphNodeLinkPoint OutputNode;

        public bool IsDragging;
        private bool isFullyDrawn;
        
#pragma warning disable 649
        [SerializeField] private LineRenderer line;
#pragma warning restore 649

        private void Awake() {
            line.startWidth = 0.5f;
            line.endWidth = 0.5f;
            line.positionCount = 2;
        }
        
        private void Update() {

            if (IsDragging) {
                if (Input.GetMouseButtonUp(0)) {
                    TryConnect(LookForNodeLinkPoint());
                } else {
                    Draw();
                }
                
            }
        }
        
        public void TryConnect(GraphNodeLinkPoint endPoint) {
            if (endPoint == null) {
                CancelConnection();
                return;
            }
            
            isFullyDrawn = true;
            IsDragging = false;
            
            if (endPoint.LinkType == LinkPointType.Input) {
                if (InputNode!=null) {
                    Debug.LogError("Cannot connect 2 inputs");
                    CancelConnection();
                    return;
                }
                InputNode = endPoint;
            }
            
            if (endPoint.LinkType == LinkPointType.Output) {
                if (OutputNode!=null) {
                    Debug.LogError("Cannot connect 2 outputs");
                    CancelConnection();
                    return;
                }
                OutputNode = endPoint;
            }
            
            InputNode.Connect(this);
            OutputNode.Connect(this);
            
            Ends.start = InputNode.transform.position;
            Ends.end = OutputNode.transform.position;
        }

        public void Disconnect() {
            InputNode.Connections.Remove(this);
            OutputNode.Connections.Remove(this);
            
            Destroy(gameObject);
        }

        #region CreationMethods

        public void StartConnecting(GraphNodeLinkPoint startPoint) {
            IsDragging = true;
            if (startPoint.LinkType == LinkPointType.Input) {
                InputNode = startPoint;
            }
            if (startPoint.LinkType == LinkPointType.Output) {
                OutputNode = startPoint;
            }

            Ends.start = startPoint.transform.position;
        }

        private void CancelConnection() {
            Destroy(gameObject);
        }
        
        private void Draw() {
            if (isFullyDrawn) {
                Ends.end = InputNode.transform.position;
                Ends.start = OutputNode.transform.position;
            } else {
                Ends.end=GameController.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            
            line.SetPosition(0,Ends.start);
            line.SetPosition(1,(Ends.end));
            
        }

        #endregion
        
        #region Helper Methods

        private static GraphNodeLinkPoint LookForNodeLinkPoint() {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            
            if (hit && hit.transform.CompareTag(TransformTags.GraphNodeLinkPoint)) {
                return hit.transform.GetComponent<GraphNodeLinkPoint>();
            }

            return null;

        }
        
        #endregion
    }
}