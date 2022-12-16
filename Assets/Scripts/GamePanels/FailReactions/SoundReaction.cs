using UnityEngine;
using WordAlgorithm.Interfaces;

namespace WordAlgorithm.GamePanels.FailReactions
{
    public class SoundReaction : IFailReaction
    {
        private const string soundName = "FailSound";
        private MonoBehaviour _monoBehaviour;
        private AudioClip _clip;
        private AudioSource _audioSource;
        
        public SoundReaction(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            LoadSound();
            CreateAudioSource();
        }

        private void LoadSound()
        {
            _clip = (AudioClip) Resources.Load($"Sounds/{soundName}");
        }

        private void CreateAudioSource()
        {
            _audioSource = _monoBehaviour.gameObject.AddComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.PlayOneShot(_clip);
        }
    }
}