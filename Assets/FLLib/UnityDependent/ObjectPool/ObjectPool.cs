using System;
using System.Collections.Generic;
using UnityEngine;

namespace FLLib.UnityDependent.ObjectPool {
    public static class ObjectPool {
        private static Dictionary<Type, Stack<GameObject>> pool = new Dictionary<Type, Stack<GameObject>>();

        private static readonly Dictionary<Type, int> softLimit = new Dictionary<Type, int> {
            
        };

        public static void destroy(Type t, GameObject obj) {
            if (!pool.ContainsKey(t)) {
                pool.Add(t, new Stack<GameObject>());
            }

            var stack = pool[t];
            if (stack.Count < softLimit[t]) {
                stack.Push(obj);
            }

            obj.SetActive(false);
        }

        public static GameObject get(Type t) {
            if (!pool.ContainsKey(t) || pool[t].Count == 0) {
                return null;
            }

            var obj = pool[t].Pop();
            obj.SetActive(true);
            return obj;
        }

        public static void Clear() {
            pool.Clear();
        }
    }
}