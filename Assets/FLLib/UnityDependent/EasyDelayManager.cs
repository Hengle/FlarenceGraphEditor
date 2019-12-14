using System;
using System.Collections;
using UnityEngine;

namespace FLLib.UnityDependent {
    public class EasyDelayManager : MonoBehaviour {
        public static EasyDelayManager instance;
        
        private void Awake() {
            if (instance == null) {
                instance = this;
            }
        }

        public void ExecuteAfter(float delay, Action f) {
            StartCoroutine(exec(delay, f));
        }

        private IEnumerator exec(float delay, Action f) {
            yield return new WaitForSeconds(delay);
            f();
        }
    }
}