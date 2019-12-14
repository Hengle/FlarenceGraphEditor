using System;
using System.Collections.Generic;
using UnityEngine;

namespace FLLib.UnityDependent.PositionalProgressTracker {
    public class PositionalProgressTrackingController : MonoBehaviour {
        
        public static PositionalProgressTrackingController Instance;

        private Queue<(float x,Action a)> XPositionEvents;
#pragma warning disable CS0649

        
        private bool IsInitialized;
        private float CurrentX;
        [SerializeField] private Transform TrackedObject;
        

        private void Awake() {
            Instance = this;
            Clear();
        }

        private void Update() {
            if (IsInitialized && XPositionEvents.Count>0) {
                var x = TrackedObject.position.x;
                if (x < XPositionEvents.Peek().x) {
                    var e = XPositionEvents.Dequeue();
                    e.a();
                }
            }
        }

        public void Initialize() {
            if (TrackedObject != null) {
                IsInitialized = true;
            } else {
                Debug.LogError("Tracked Object was not set!");
            }
        }

        public void AddAtX(float x, Action f) {
            if (false == IsInitialized) {
                if (XPositionEvents.Count == 0 || XPositionEvents.Peek().x >= x) {
                    XPositionEvents.Enqueue((x, f));
                } else {
                    Debug.LogError("Incorrect order of events added at x="+x);
                }
            }
           
        }

        public void Clear() {
            XPositionEvents=new Queue<(float,Action)>();
        }
    }
}