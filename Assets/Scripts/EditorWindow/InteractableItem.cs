using UnityEngine;

namespace FlarenceGraphEditor.EditorWindow {
    public abstract class InteractableItem : MonoBehaviour {

        public abstract string ItemName { get; }
        
        public abstract void OnLeftClickDown();

        public virtual void OnCreatedFromInventory() {
            
        }

    }
}