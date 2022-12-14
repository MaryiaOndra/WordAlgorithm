using System;
using UnityEngine;
using UnityEngine.UI;

namespace WordAlgorithm
{
    [RequireComponent(typeof(Canvas))]
    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        
        private Canvas _startCanvas;
        public event Action StartGame;

        private void Awake()
        {
            _startCanvas = GetComponent<Canvas>();
        }

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
            _startCanvas.enabled = false;
        }
    }
}
