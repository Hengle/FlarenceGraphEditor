using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FLLib.UnityDependent.TextHelpers {
    public class TextFontFadeHelper : MonoBehaviour {
        public static TextFontFadeHelper Instance;

        private Dictionary<TMP_Text, Coroutine> storedCoroutines;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                storedCoroutines= new Dictionary<TMP_Text, Coroutine>();
            } else {
                Destroy(gameObject);
                Debug.LogWarning("TextFontFadeHelper duplicate deleted");
            }
        }

        public void FadeOutTextSafe(TMP_Text element) {
            if (storedCoroutines.ContainsKey(element)) {
                StopCoroutine(storedCoroutines[element]);
                storedCoroutines.Remove(element);
                element.color=new Color(element.color.r,element.color.b,element.color.g,1f);
            }
            var crt=StartCoroutine(FadeOutTextCoroutine(element));
            storedCoroutines.Add(element,crt);
        }
        
        
        public void FadeOutText(TMP_Text element) {
            StartCoroutine(FadeOutTextCoroutine(element));
        }

        private IEnumerator FadeOutTextCoroutine(TMP_Text element) {
            var originalColor = element.color;
            var tmpColor = originalColor;
            var at = 1f;
            var step = 0.1f;
            while (at>=0) {
                tmpColor.a = at;
                element.color = tmpColor;
                at -= step;
                yield return new WaitForSeconds(0.05f);
            }

            element.text = "";
            element.color = originalColor;

            if (storedCoroutines.ContainsKey(element)) {
                storedCoroutines.Remove(element);
            }
        }
        
        
    }
}