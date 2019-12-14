using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;


namespace FLLib.BiasSelection {
    public static class RouletteSelection {

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static T pick<T>([CanBeNull] IEnumerable<T> items) where T :  IWeightedItem  {
            if (items == null || false==items.Any()) {
                return default(T);
            }
            
            var sum = items.Sum(item => item.weight);
            var randomValue = Random.Range(0, sum);
            var current = 0;
            foreach (var item in items) {
                if (item.weight + current >= randomValue) {
                    return item;
                }
                current += item.weight;
            }

            return items.Last();
        }        
    }
}