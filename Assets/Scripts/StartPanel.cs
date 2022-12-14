using System;
using UnityEngine;
using UnityEngine.UI;

namespace WordAlgorithm
{
    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Canvas startCanvas;

        public event Action StartGame;
        
        private void OnEnable()
        {
            startButton.onClick.AddListener(OnStartGame);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(OnStartGame);
        }

        private void OnStartGame()
        {
            StartGame?.Invoke();
            startCanvas.enabled = false;
        }
    }
}
