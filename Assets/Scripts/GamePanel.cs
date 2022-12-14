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
            Debug.Log("INIT GamePanel");
            InitGrid(gridConfig.grid);
        }

        private void InitGrid(List<List<string>> grid)
        {
            Debug.Log("INIT GRID");
            
            for (int i = 0; i < grid.Count; i++)
            {
               var newRow = Instantiate(rowPrefab, parentForRows);
               newRow.name = "Row";
               newRow.Init(grid[i]);
            }
        }
    }
}
