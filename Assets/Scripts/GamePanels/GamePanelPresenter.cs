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
        private GridConfig _config;
        private GamePanelView _panelView;
        

        public GamePanelPresenter(GamePanelView panelView, GridConfig config)
        {
            _panelView = panelView;
            _config = config;
            panelView.ConfirmButton.onClick.AddListener(CheckResult);
            _panelView.InitGrid(config.Grid);
            InitFailReactions(config.ReactionType);
            CreateCheker();
        }

        // public void Init(GridConfig gridConfig)
        // {
        //     GridConfig = gridConfig;
        //     confirmButton.onClick.AddListener(CheckResult);
        //     InitGrid(gridConfig.Grid);
        //     InitFailReactions(gridConfig.ReactionType);
        //     CreateCheker();
        // }

        private void CreateCheker()
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

        // private void InitGrid(List<List<string>> grid)
        // {
        //     for (int i = 0; i < grid.Count; i++)
        //     {
        //         var newRow = _panelView.gameObject.Instantiate(rowPrefab, parentForRows);
        //         newRow.name = _nameOfRow;
        //         newRow.Init(grid[i], i);
        //         // _gameWordGrid.Add(i, newRow.WordCells);
        //     }
        // }

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