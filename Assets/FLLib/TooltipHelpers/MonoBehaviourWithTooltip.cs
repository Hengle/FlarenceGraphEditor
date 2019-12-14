using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace FLLib.TooltipHelpers {
    public class MonoBehaviourWithTooltip: MonoBehaviour {

        [HideInInspector]
        public string TooltipString { get; protected set; }
        
        [HideInInspector]
        public TMP_Text TooltipText { get; private set; }
        
        [HideInInspector]
        public Transform Tooltip { get; private set; }

        [Header("Tooltip:")] 
        public Vector3 TooltipOffset;
        public Vector3 TooltipScale=Vector3.one;

        private SpriteRenderer SpriteRenderer;

        #region Constants

        private const float ShowDelay = 1f;

        private const float FadeInSpeed = 0.05f;

        #endregion

        private Coroutine TooltipFade;
        
        protected virtual void OnMouseEnter() {

            if (TooltipController.Instance.ShowTooltips && false==string.IsNullOrEmpty(TooltipString)) {

                Tooltip = Instantiate(TooltipController.Instance.TooltipPrefab.transform, transform);

                Tooltip.localScale = TooltipScale;
                
                var realOffset = new Vector3(
                    transform.position.x > 0 ? -TooltipOffset.x : TooltipOffset.x,
                    TooltipOffset.y
                );
                
                Tooltip.localPosition = realOffset;
                TooltipText = Tooltip.GetComponentInChildren<TMP_Text>();
                SpriteRenderer = Tooltip.GetComponentInChildren<SpriteRenderer>();

                SpriteRenderer.color = new Color(1, 1, 1, 0);
                TooltipText.color = new Color(1, 1, 1, 0);

                TooltipFade = StartCoroutine(FadeInText());

                TooltipText.text = TooltipString;
            }
        }

        protected virtual void OnMouseExit() {
            DestroyTooltip();
        }

    
        
        protected virtual void DestroyTooltip() {
            if (Tooltip != null) {
                StopCoroutine(TooltipFade);
                Destroy(Tooltip.gameObject);
            }
        }

        IEnumerator FadeInText() {
            yield return new WaitForSeconds(ShowDelay);
            var at = 0f;
            while (at < 1) {
                SpriteRenderer.color=new Color(1,1,1,at);
                TooltipText.color=new Color(0,0,0,at);
                at += FadeInSpeed;
                yield return new WaitForEndOfFrame();
            }
        }
        
    }
}