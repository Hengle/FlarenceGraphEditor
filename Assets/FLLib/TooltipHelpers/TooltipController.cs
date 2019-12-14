using System;
using UnityEngine;

namespace FLLib.TooltipHelpers {
    public class TooltipController :MonoBehaviour{

        public static TooltipController Instance;

        public GameObject TooltipPrefab;

        public bool ShowTooltips;
        
        private void Awake() {
            Instance = this;
            ShowTooltips = true;
        }

        
    }
}