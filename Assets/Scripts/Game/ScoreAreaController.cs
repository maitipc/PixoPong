using PixoPong.General;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace PixoPong.Game
{
    public class ScoreAreaController : MonoBehaviour
    {
        private AudioSource audioSource;
        public static event Action<bool> OnEnterScoreArea;
        public bool isPlayerScoreArea;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnterScoreArea?.Invoke(isPlayerScoreArea);
            audioSource.Play();
        }
    }
}

