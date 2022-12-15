using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using WordAlgorithm.Configs;
using WordAlgorithm.GamePanels.FailReactions;
using WordAlgorithm.Interfaces;
using WordAlgorithm.Utilities;

namespace WordAlgorithm.GamePanels
{
    public class GamePanelPresenter
    {
        private string _nameOfRow = "Row";
        private GamePanelChecker _panelChecker;
        private IFailReaction _failReaction;
        private GamePanelView _panelView;
        
        public GamePanelPresenter(GamePanelView panelView, GridConfig config)
        {
            _panelView = panelView;
            panelView.ConfirmButton.onClick.AddListener(CheckResult);
            _panelView.InitGrid(config.Grid);
            InitFailReactions(config.ReactionType);
            CreateChecker();
        }

        private void CreateChecker()
        {
            _panelChecker = new();
            _panelChecker.OnWinInput += PlayWinReaction;
            _panelChecker.FailInput += PlayFailReaction;
        }

        private void CheckResult()
        {
            if (_panelView.InputText.IsEmpty())
            {
                PlayFailReaction();
                Debug.LogAssertion("Input field is empty!");
                return;
            }

            _panelChecker.CheckStrings(_panelView.InputText, _panelView);
        }

        private void PlayFailReaction()
        {
            _failReaction.Play();
            _panelView.InputText = string.Empty;
        }

        private void PlayWinReaction(List<LetterConfig> wordConfig)
        {
            _panelView.InvokeGuessedRight(wordConfig);
            _panelView.InputText = string.Empty;
        }
        
        private void InitFailReactions(FailReactionType reactionType)
        {
            switch (reactionType)
            {
                case FailReactionType.Sound:
                    _failReaction = new SoundReaction(_panelView);
                    break;
                case FailReactionType.Shake:
                    _failReaction = new ShakeReaction(_panelView.transform);
                    break;
            }
        }
    }
}