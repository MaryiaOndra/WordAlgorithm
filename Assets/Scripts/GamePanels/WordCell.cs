using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using ModestTree;
using TMPro;
using UnityEngine;
using WordAlgorithm.Configs;
using WordAlgorithm.Utilities;
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
            _gamePanelView.GuessedWrong += FailReaction;
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

        //TODO: add reactions to another class
        public void OpenLetterReaction()
        {
            letterText.DOFade(1f, timeToOpen);
            _isOpened = true;
        }

        public void FailReaction(FailReactionType reactionType )
        {
            switch (reactionType)
            {
                case FailReactionType.Sound:
                    Debug.Log("FAIL REACTION SOUND");
                    break;
                case FailReactionType.Shake:
                    Debug.Log("FAIL REACTION SHAKE");
                    transform.DOPunchScale(Vector3.one, 0.5f);
                    break;
            }
        }
    } 
}
