using UnityEngine;

namespace FLLib.UnityDependent {
    public static class V3Extensions {

        public static Vector3 xPlus(this Vector3 vec, float amount){
            return vec + new Vector3(amount, 0, 0);
        }
        
        public static Vector3 yPlus(this Vector3 vec, float amount){
            return vec + new Vector3(0, amount, 0);
        }
        
        public static Vector3 zPlus(this Vector3 vec, float amount){
            return vec + new Vector3(0, 0, amount);
        }
    }
}