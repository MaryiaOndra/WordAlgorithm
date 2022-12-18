using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
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

        private List<WordRow> _wordRows = new();
        
        public Button ConfirmButton => confirmButton;
        public string InputText { 
            get => inputField.text;
            set => inputField.text = value;
        }

        private string _nameOfRow = "Row";
        
        public void InvokeGuessedRight(List<LetterConfig> letterConfigs)
        {
            CheckCellsToOpen(letterConfigs);
            inputField.text = string.Empty;
        }

        private async void CheckCellsToOpen(List<LetterConfig> letterConfigs)
        {
            foreach (var wordRow in _wordRows)
            {
                foreach (var gameCell in wordRow.WordCells)
                {
                    bool isCellNeedToOpen = letterConfigs.Any(cell =>
                        cell.Position == gameCell.Position);

                    if (isCellNeedToOpen && !gameCell.IsOpened)
                    {
                        LetterConfig configCell = letterConfigs.First(cell =>
                            cell.Position == gameCell.Position);
                        await gameCell.OpenCellWithText(configCell.Letter);
                    }
                }
            }
        }

        public void InitGrid(List<List<string>> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
               var newRow = Instantiate(rowPrefab, parentForRows);
               newRow.name = _nameOfRow;
               newRow.Init(grid[i], i);
               _wordRows.Add(newRow);
            }
        }
    }
}
