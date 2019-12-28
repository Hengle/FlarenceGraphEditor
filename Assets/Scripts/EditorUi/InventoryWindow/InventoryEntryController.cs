using FlarenceGraphEditor.EditorWindow;
using TMPro;
using UnityEngine;

namespace FlarenceGraphEditor.EditorUi.InventoryWindow {
    
    public class InventoryEntryController : InteractableItem {

        public override string ItemName => "Inventory Entry";
        
        [SerializeField] private TMP_Text Label;
        
        private GameObject _itemPrefab;
        public GameObject ItemPrefab {
            get => _itemPrefab;
            set {
                _itemPrefab = value;
                Label.text = value.GetComponent<InteractableItem>().ItemName;
            }
        }

        private void CreateEntry() {
            var item = Instantiate(ItemPrefab, GameController.Instance.EditorArea);
            item.GetComponent<InteractableItem>().OnCreatedFromInventory();
        }

        #region Interactable Object Implementation

        public override void OnLeftClickDown() {
            CreateEntry();
        }

        #endregion
    }
}