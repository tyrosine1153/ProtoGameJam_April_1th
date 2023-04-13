using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "ScriptableObjects/AudioClips", order = 0)]
public class AudioClipsScriptableObject : ScriptableObject
{
    [Serializable]
    public struct ClipList<T> where T : Enum
    {
        [Serializable]
        public struct Clip
        {
            public T type;
            public AudioClip audioClip;
        }
        
        [SerializeField]
        private List<Clip> clips;
        
        public AudioClip this[T type]
        {
            get
            {
                return clips.FirstOrDefault(bgmClip => bgmClip.type.Equals(type)).audioClip;
            }
        }
    }
    
    public ClipList<BGMType> bgmClips;
    
    public ClipList<SFXType> sfxClips;
}
