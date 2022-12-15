using System;
using UnityEngine;
using UnityEngine.UI;

namespace WordAlgorithm.GamePanels
{
    [RequireComponent(typeof(Canvas))]
    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        
        private Canvas _startCanvas;
        public event Action StartButtonPressed;

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
            StartButtonPressed?.Invoke();
        }

        public void DisableScreen()
        {
            _startCanvas.enabled = false;
        }
    }
}
