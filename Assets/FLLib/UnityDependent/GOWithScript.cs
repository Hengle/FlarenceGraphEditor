using UnityEngine;

namespace FLLib.UnityDependent {
    public struct GOWithScript<TMonoBehaviour> where TMonoBehaviour : MonoBehaviour {
        public GameObject gameObject;
        public TMonoBehaviour script;

        public GOWithScript(GameObject gameObject, TMonoBehaviour script) : this() {
            this.gameObject = gameObject;
            this.script = script;
        }
        
    }
}