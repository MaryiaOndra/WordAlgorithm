using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using ModestTree;
using TMPro;
using UnityEngine;
using WordAlgorithm.Configs;
using WordAlgorithm.Interfaces;
using Zenject;

namespace WordAlgorithm.GamePanels
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WordCell : MonoBehaviour
    {
        [SerializeField] private TMP_Text letterText;
        [SerializeField] private float timeToOpen = 0.5f;
        
        private CanvasGroup  _canvasGroup;
        private IFailReaction _failReaction;

        /// <summary>
        /// position of the cell where X is row, Y is column
        /// </summary>
        public Vector2 Position { get; private set; }
        public bool IsOpened { get; private set; }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Init(string letter, Vector2 position)
        {
            CheckIfEmpty(letter);
            Position = position;
        }

        private void CheckIfEmpty(string letter)
        {
            var trimmedLetter = letter.Trim();
            
            if (trimmedLetter.IsEmpty())
            {
                _canvasGroup.DOFade(0f, 0f);
            }
            else
            {
                letterText.text = letter;
                letterText.DOFade(0f, 0f);
            }
        }
        
        public async Task OpenCellWithText(string letter)
        {
            letterText.text = letter;
            var fadeTask = letterText.DOFade(1f, timeToOpen);
            while(fadeTask.IsActive())
            {
                await Task.Yield();
            }
            IsOpened = true;
        }
    } 
}
