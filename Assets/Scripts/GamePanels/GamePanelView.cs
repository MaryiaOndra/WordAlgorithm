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

        public event Action<List<LetterConfig>> GuessedRight;

        public void InvokeGuessedRight(List<LetterConfig> letterConfigs)
        {
            GuessedRight?.Invoke(letterConfigs);
            inputField.text = string.Empty;
        }

        public void InitGrid(List<List<string>> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
               var newRow = Instantiate(rowPrefab, parentForRows);
               newRow.name = _nameOfRow;
               newRow.Init(grid[i], i);
            }
        }
    }
}
