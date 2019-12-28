using System.Collections.Generic;
using FlarenceGraphEditor.EditorUi.InfoPanel;
using UnityEngine;

namespace FlarenceGraphEditor.EditorWindow.Nodes.GraphNodeLinkPoints {
    public class GraphNodeLinkPointController : InteractableItem{
        
        public override string ItemName => "Graph Node Link Point";
        
        public LinkPointType LinkType;
        public GraphNodeController ParentNode;
        public HashSet<InterNodeConnection> Connections;
        
        public bool AllowMultipleConnection=true;

        private void Awake() {
            Connections=new HashSet<InterNodeConnection>();
        }

        public void Connect(InterNodeConnection connection) {
            if (false==AllowMultipleConnection) {
                DebugInfoPanelController.Instance.ShowMessage(
                    "This type of Node link point can only have one active connection at a time");
                DisconnectAll();
            }
            Connections.Add(connection);
        }

        public void DisconnectAll() {
            foreach (var connection in Connections) {
                Disconnect(connection);
            }
        }
        
        public void Disconnect(InterNodeConnection connection) {
            connection.Disconnect();
        }

        public void StartNewConnection() {
            var connectionObject = Instantiate(GameController.Instance.ConnectionPrefab);
            connectionObject.transform.position = transform.position;
            connectionObject.transform.SetParent(transform);
            var connection = connectionObject.GetComponent<InterNodeConnection>();
            connection.StartConnecting(this);
        }
        
        #region Interactable Object Implementation

        public override void OnLeftClickDown() {
            StartNewConnection();
        }

        #endregion

        
    }
}