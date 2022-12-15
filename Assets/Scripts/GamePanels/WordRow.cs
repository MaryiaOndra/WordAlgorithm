using System.Collections.Generic;
using UnityEngine;

namespace WordAlgorithm.GamePanels
{
    public class WordRow : MonoBehaviour
    {
        [SerializeField] private WordCell cellPrefab;

        public List<WordCell> WordCells { get; } = new List<WordCell>();

        public void Init(List<string> lettersList, int rowIndex)
        {
            for (int i = 0; i < lettersList.Count; i++)
            {
               WordCell newCell = Instantiate(cellPrefab, this.transform);
               newCell.name = "WordCell";
               newCell.Init(lettersList[i], new Vector2(rowIndex, i));
               WordCells.Add(newCell);
            }
        }
    }
}
