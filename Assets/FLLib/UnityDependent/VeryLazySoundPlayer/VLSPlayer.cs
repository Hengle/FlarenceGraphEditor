using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FLLib.UnityDependent.VeryLazySoundPlayer {
    
    
    public class VLSPlayer : MonoBehaviour {
        // ReSharper disable once UnassignedField.Global
        public AudioSource AudioSource;

        public bool PlayOnAwake;
        public int PlayOnAwakeIndex;
        
        [Serializable]
        public struct InspectorStruct{
            public AudioClip Clip;
            // ReSharper disable once UnassignedField.Global
            public VLSPlayerPitchType PitchType;
            [Tooltip("Only Relevant if PitchType set to \"Randomized\"")]
            // ReSharper disable once UnassignedField.Global
            [Range(0.0f, 0.5f)]public float PitchRange;
        }
 
        [SerializeField]
#pragma warning disable 649
        private List<InspectorStruct> AudioClips;
#pragma warning restore 649

        void Awake() {
            if (PlayOnAwake) {
                PlaySound(PlayOnAwakeIndex);
            }
        }
        
        
        public void PlaySound1() {
            PlaySound(0);
        }
        
        public void PlaySound2() {
            PlaySound(1);
        }
        
        public void PlaySound3() {
            PlaySound(2);
        }
        
        public void PlaySound4() {
            PlaySound(3);
        }
        
        public void PlaySound5() {
            PlaySound(4);
        }
        

        private void PlaySound(int at) {
            var clip = AudioClips[at];
            if (clip.PitchType == VLSPlayerPitchType.Randomized) {
                AudioSource.pitch = Random.Range(-clip.PitchRange / 2, clip.PitchRange / 2) + 1;
            } else {
                AudioSource.pitch = 1;
            }
            AudioSource.PlayOneShot(clip.Clip);
        }
        
    }
}