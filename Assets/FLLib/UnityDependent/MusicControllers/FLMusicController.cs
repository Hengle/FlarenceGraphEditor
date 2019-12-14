using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FLLib.UnityDependent;
using FLLib.UnityDependent.TextHelpers;
using TMPro;
using UnityEngine;

namespace FLLib.UnityDependent.MusicControllers {
    public class FLMusicController :MonoBehaviour{
        public static FLMusicController Instance;

        public bool KeepPlaying = true;
        //public bool Shuffle = false;
        private int CurrentSongIndex = 0;

#pragma warning disable CS0649

        [SerializeField] private TextMeshProUGUI SongNameText;
        [SerializeField] private TextMeshProUGUI ArtistNameText;
        
        
        [Serializable]
        public struct InspectorSongStruct {
            public string Name;
            public string Artist;
            public AudioClip Song;
        }
        #pragma warning disable CS0649
        public List<InspectorSongStruct> Songs;

        private AudioSource _audioSource;
        
        
        
        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
                Debug.LogWarning("FLMusicController duplicate deleted");
            }

            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = 0.4f;
        }

        public void PlayNextSong() {
            this._PlayNextSong(false);
        }

        private void _PlayNextSong(bool isAutoplay = false) {
            if (false == isAutoplay || KeepPlaying) {
                if (EasyDelayManager.instance == null) {
                    Debug.LogError("FLMusicController requires an instance of EasyDelayManager in the scene to function <b>or</b> should be called after the scene has loaded");
                    return;
                }
                if (TextFontFadeHelper.Instance == null) {
                    Debug.LogError("FLMusicController requires an instance of TextFontFadeHelper in the scene to function <b>or</b> should be called after the scene has loaded");
                    return;
                }

                var song = GetNextSong();
                
                _audioSource.PlayOneShot(song.Song);
                ArtistNameText.text = song.Artist;
                SongNameText.text = song.Name;
                
                EasyDelayManager.instance.ExecuteAfter(5, () => {
                    TextFontFadeHelper.Instance.FadeOutText(ArtistNameText);
                    TextFontFadeHelper.Instance.FadeOutText(SongNameText);
                });
                
                EasyDelayManager.instance.ExecuteAfter(song.Song.length+1,()=>_PlayNextSong(true));
            }
        }

        private InspectorSongStruct GetNextSong() {
            var song = Songs.ElementAt(CurrentSongIndex);
            CurrentSongIndex++;
            if (CurrentSongIndex >= Songs.Count) {
                CurrentSongIndex = 0;
            }

            return song;
        }
    }
}