#undef DEBUG

using System;
using System.Collections.Generic;
using UnityEngine;

namespace FLLib.UnityDependent.GoKitAddons.SafeGoKit {
    public static class SafeGoKit {
        private static Dictionary<Transform, GoTweenTypes> runningTweens;
        
        public static GoTween positionToEasedSafe(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative = false) {
            if (runningTweens == null) {
                runningTweens=new Dictionary<Transform, GoTweenTypes>();
            }
            
            if (false == runningTweens.ContainsKey(t)) {
                runningTweens.Add(t, new GoTweenTypes());
            }

            if ((runningTweens[t].localPosition == null || runningTweens[t].localPosition.state != GoTweenState.Running) && (runningTweens[t].position == null || runningTweens[t].position.state != GoTweenState.Running)) {
                var tween = t.positionToEased(easeType, duration, endValue, isRelative);
                runningTweens[t].position = tween;
                return tween;
            } else {
#if DEBUG
        Debug.Log(t.displayName+" new position Tween was ignored \n easeType: "+easeType.ToString()
                          +"\n duration: "+duration
                          +"\n endValue: "+endValue.ToString());           
#endif
                             
                return null;
            }
        }

        public static GoTween localPositionToEasedSafe(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false) {                     
            if (runningTweens == null) {
                runningTweens=new Dictionary<Transform, GoTweenTypes>();
            }
            
            if (false == runningTweens.ContainsKey(t)) {
                runningTweens.Add(t,new GoTweenTypes());                
            }
         
            if ((runningTweens[t].localPosition == null || runningTweens[t].localPosition.state != GoTweenState.Running) && (runningTweens[t].position == null || runningTweens[t].position.state != GoTweenState.Running)) {
                var tween=t.localPositionToEased(easeType, duration, endValue, isRelative);
                runningTweens[t].localPosition = tween;
                return tween;
            } else {
#if DEBUG
        Debug.Log(t.displayName+" new position Tween was ignored \n easeType: "+easeType.ToString()
                          +"\n duration: "+duration
                          +"\n endValue: "+endValue.ToString());           
#endif
                return null;
            }
        }

        public static GoTween rotationToEasedSafe(this Transform t, GoEaseType easeType, float duration,Vector3 endValue, bool isRelative = false, bool isForced=false) {
            if (runningTweens == null) {
                runningTweens = new Dictionary<Transform, GoTweenTypes>();
            }

            if (false == runningTweens.ContainsKey(t)) {
                runningTweens.Add(t, new GoTweenTypes());
            }

            if (isForced) {
                if (runningTweens[t].rotation != null) {
                    runningTweens[t].rotation.destroy();
                }
            }

            if ((runningTweens[t].rotation == null || runningTweens[t].rotation.state != GoTweenState.Running)) {
                var tween = t.rotationToEased(easeType, duration, endValue, isRelative);
                runningTweens[t].rotation = tween;
                return tween;
            } else {
#if DEBUG
        Debug.Log(t.displayName+" new position Tween was ignored \n easeType: "+easeType.ToString()
                          +"\n duration: "+duration
                          +"\n endValue: "+endValue.ToString());
#endif
                return null;
            }
        }

        public static GoTween scaleToEasedSafe(this Transform t, GoEaseType easeType, float duration, Vector3 endValue, bool isRelative=false , bool isForced=false){
            if (runningTweens == null) {
                runningTweens=new Dictionary<Transform, GoTweenTypes>();
            }
            
            if (false == runningTweens.ContainsKey(t)) {
                runningTweens.Add(t,new GoTweenTypes());                
            }

            if (isForced) {
                if (runningTweens[t].scale != null) {
                    runningTweens[t].scale.destroy(); 
                }               
            }
         
            if ((runningTweens[t].scale == null || runningTweens[t].scale.state != GoTweenState.Running)) {
                var tween=t.scaleToEased(easeType, duration, endValue, isRelative);
                runningTweens[t].scale = tween;
                return tween;
            } else {
#if DEBUG
        Debug.Log(t.displayName+" new position Tween was ignored \n easeType: "+easeType.ToString()
                          +"\n duration: "+duration
                          +"\n endValue: "+endValue.ToString());           
#endif
                return null;
            }        
        }

        public static void forcePositionSafe(this Transform t, Vector3 position) {
            if (runningTweens != null && runningTweens.ContainsKey(t) ) {
                if (runningTweens[t].position != null) {
                    runningTweens[t].position.destroy();
                }
                if (runningTweens[t].localPosition != null) {
                    runningTweens[t].localPosition.destroy();
                }
            }

            t.position = position;
        }
        
        public static void forceScaleSafe(this Transform t, Vector3 scale) {
            if (runningTweens != null && runningTweens.ContainsKey(t) ) {
                if (runningTweens[t].scale != null) {
                    runningTweens[t].scale.destroy();
                }
            }

            t.localScale = scale;
        }

        public static bool isSafeMoveFree(this Transform t) {
            return runningTweens == null ||
                   false == runningTweens.ContainsKey(t) ||
                   ((runningTweens[t].localPosition == null ||
                     runningTweens[t].localPosition.state != GoTweenState.Running)
                    && (runningTweens[t].position == null || runningTweens[t].position.state != GoTweenState.Running));
        }
        
        public static void clear() {
            if (runningTweens != null) {
                runningTweens.Clear();
            }
        }

    }
}