using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WordAlgorithm
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private Button confirmButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private WordGridRow rowPrefab;
        [SerializeField] private Transform parentForRows;
        
        public void Init(GridConfig gridConfig)
        {
            confirmButton.onClick.AddListener(CheckResult);
            InitGrid(gridConfig.grid);
        }

        private void CheckResult()
        {
            Debug.Log($"Check: {inputField.text}");
        }

        private void InitGrid(List<List<string>> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
               var newRow = Instantiate(rowPrefab, parentForRows);
               newRow.name = "Row";
               newRow.Init(grid[i]);
            }
        }
    }
}
