using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FLLib.UnityDependent.GoKitAddons {
    public static class Extensions {

        public static GoTween positionToEased(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false){
            var originalEaseType = Go.defaultEaseType;
            Go.defaultEaseType = easeType;
            var tween=t.positionTo(duration, endValue, isRelative);
            Go.defaultEaseType=originalEaseType;
            return tween;
        }
        
        public static GoTween localPositionToEased(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false){
            var originalEaseType = Go.defaultEaseType;
            Go.defaultEaseType = easeType;
            var tween=t.localPositionTo(duration, endValue, isRelative);
            Go.defaultEaseType=originalEaseType;
            return tween;
        }
        
        public static GoTween rotationToEased(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false){
            var originalEaseType = Go.defaultEaseType;
            Go.defaultEaseType = easeType;
            var tween=t.rotationTo(duration, endValue, isRelative);
            Go.defaultEaseType=originalEaseType;
            return tween;
        }
        
        public static GoTween scaleToEased(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false){
            var originalEaseType = Go.defaultEaseType;
            Go.defaultEaseType = easeType;
            var tween=t.scaleTo(duration, endValue, isRelative);
            Go.defaultEaseType=originalEaseType;
            return tween;        
        }

        public static GoTween colorToEased(this SpriteRenderer sr,GoEaseType easeType, float duration, Color endValue){
            var originalEaseType = Go.defaultEaseType;
            Go.defaultEaseType = easeType;
            var tween=sr.material.colorTo(duration, endValue);
            Go.defaultEaseType=originalEaseType;
            return tween;
        }
    }
}