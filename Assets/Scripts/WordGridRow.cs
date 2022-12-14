using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordAlgorithm
{
    public class WordGridRow : MonoBehaviour
    {
        [SerializeField] private WordCell cellPrefab;
        
        private List<WordCell> _wordCells;

        public void Init(List<string> lettersList)
        {
            for (int i = 0; i < lettersList.Count; i++)
            {
               WordCell newCell = Instantiate(cellPrefab, this.transform);
               newCell.name = "WordCell";
               newCell.Init(lettersList[i]);
            }
        }
    }
}
