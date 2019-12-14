using System;
using Random = UnityEngine.Random;

namespace FLLib.UnityDependent.GoKitAddons {
    public static class EaseTypeHelper {
        public static GoEaseType randomEaseType {
            get { return (GoEaseType) Random.Range(0, Enum.GetValues(typeof(GoEaseType)).Length-1); }
        }
    }
}