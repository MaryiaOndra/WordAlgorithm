using System.Collections.Generic;
using System.Linq;
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
        [Inject] private GamePanelView _gamePanelView;
        [SerializeField] private TMP_Text letterText;
        [SerializeField] private float timeToOpen = 0.5f;
        
        private CanvasGroup  _canvasGroup;
        private bool _isOpened;
        private IFailReaction _failReaction;
        
        /// <summary>
        /// position of the cell where X is row, Y is column
        /// </summary>
        private Vector2 _position; 

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Init(string letter, Vector2 position)
        {
            CheckIfEmpty(letter);

            _gamePanelView.GuessedRight += CheckLetterToOpen;
            _position = position;
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
        
        private void CheckLetterToOpen(List<LetterConfig> configs)
        {
            bool isCellNeedToOpen = configs.Any(cell =>
                (cell.ColumnIndex == _position.y) && (cell.RowIndex == _position.x));
            
            if(isCellNeedToOpen && !_isOpened)
                OpenLetterReaction();
        }

        public void OpenLetterReaction()
        {
            letterText.DOFade(1f, timeToOpen);
            _isOpened = true;
        }
    } 
}
