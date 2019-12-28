using System.Collections.Generic;
using FlarenceGraphEditor.EditorWindow;
using UnityEngine;

namespace FlarenceGraphEditor.EditorUi.InventoryWindow {
    public class InventoryWindowController :  MonoBehaviour {

        public static InventoryWindowController Instance;
        
        // ReSharper disable once CollectionNeverUpdated.Global
        public List<GameObject> Prefabs;

        // ReSharper disable once UnassignedField.Global
        public GameObject InventoryEntryPrefab;

        private void Awake() {
            Instance = this;
            
            foreach (var prefab in Prefabs) {
                var inventoryEntry = Instantiate(InventoryEntryPrefab, transform);
                inventoryEntry.GetComponent<InventoryEntryController>().ItemPrefab = prefab;
            }
        }
    }
}