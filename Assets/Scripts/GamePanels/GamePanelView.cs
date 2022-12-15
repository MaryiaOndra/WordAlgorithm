using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WordAlgorithm.Configs;
using WordAlgorithm.Interfaces;
using Zenject;

namespace WordAlgorithm.GamePanels
{
    public class GamePanelView : MonoBehaviour
    {
        [Inject] public IWordOrganizer WordOrganizer { get; private set; }

        [SerializeField] private Button confirmButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private WordRow rowPrefab;
        [SerializeField] private Transform parentForRows;

        public Button ConfirmButton => confirmButton;
        public string InputText { 
            get => inputField.text;
            set => inputField.text = value;
        }

        private string _nameOfRow = "Row";
        // private GamePanelChecker _panelChecker;
        // private IFailReaction _failReaction;
        // public Dictionary<int,List<WordCell>> GameWordGrid { get; private set; } = new();
        // public GridConfig GridConfig { get; private set; }
        //
        public event Action<List<LetterConfig>> GuessedRight;

        public void InvokeGuessedRight(List<LetterConfig> letterConfigs)
        {
            GuessedRight?.Invoke(letterConfigs);
            inputField.text = string.Empty;
        }

        //
        // public void Init(GridConfig gridConfig)
        // {
        //     GridConfig = gridConfig;
        //     confirmButton.onClick.AddListener(CheckResult);
        //     InitGrid(gridConfig.Grid);
        //     InitFailReactions(gridConfig.ReactionType);
        //     CreateCheker();
        // }
        //
        // private void CreateCheker()
        // {
        //     _panelChecker = new();
        //     _panelChecker.OnWinInput += PlayWinReaction;
        //     _panelChecker.FailInput += PlayFailReaction;
        // }
        //
        // private void CheckResult()
        // {
        //     if (inputField.text.IsEmpty())
        //     {
        //         PlayFailReaction();
        //         Debug.LogAssertion("Input field is empty!");
        //         return;
        //     }
        //
        //     _panelChecker.CheckStrings(inputField.text, this);
        // }
        //
        public void InitGrid(List<List<string>> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
               var newRow = Instantiate(rowPrefab, parentForRows);
               newRow.name = _nameOfRow;
               newRow.Init(grid[i], i);
               //GameWordGrid.Add(i, newRow.WordCells);
            }
        }
        
        //
        // private void PlayFailReaction()
        // {
        //     _failReaction.Play();
        //     inputField.text = string.Empty;
        // }
        //
        // private void PlayWinReaction(List<LetterConfig> wordConfig)
        // {
        //     GuessedRight?.Invoke(wordConfig);
        //     inputField.text = string.Empty;
        // }
        //
        // private void InitFailReactions(FailReactionType reactionType)
        // {
        //     switch (reactionType)
        //     {
        //         case FailReactionType.Sound:
        //             _failReaction = new SoundReaction(this);
        //             break;
        //         case FailReactionType.Shake:
        //             _failReaction = new ShakeReaction(transform);
        //             break;
        //     }
        // }
    }
}
