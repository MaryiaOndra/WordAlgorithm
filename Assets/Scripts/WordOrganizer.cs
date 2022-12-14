using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace WordAlgorithm
{
    public class WordOrganizer
    {
        private Dictionary<string, List<LetterConfig>> lettersConfigs = new();
        public void OrganizeWordList(List<List<string>> gridConfig)
        {
            FindHorizontalWords(gridConfig);
            //FindVerticalWords(gridConfig);
            Debug.Log("KEYS: " +  lettersConfigs.Keys.Count);
            foreach (var key in lettersConfigs.Keys)
            {
              Debug.Log($"Horizontal words: {key}");  
            }
        }
        
        private void FindHorizontalWords(List<List<string>> gridConfig)
        {
            for (int i = 0; i < gridConfig.Count; i++)
            {
                List<LetterConfig> newLettersConfigs = new List<LetterConfig>();
                string newWord = String.Empty;
                
                for (int j = 0; j < gridConfig[i].Count; j++)
                {
                    var trimmedLetter =  gridConfig[i][j].Trim();
                    
                    Debug.Log($"Trimmed letter words: [{trimmedLetter}]");  
                    
                    if (trimmedLetter.IsEmpty())
                    {
                        if (newWord.Length < 3)
                        {
                            newLettersConfigs.Clear();
                            newWord = String.Empty;
                        }
                        continue;
                    }
                    
                    Debug.Log($"Add Trimmed letter to newLettersConfigs: [{trimmedLetter}]");  
                    LetterConfig newLetter = new LetterConfig( trimmedLetter,i, j);
                    newLettersConfigs.Add(newLetter);
                    newWord += trimmedLetter;
                }

                if (newLettersConfigs.Count >= 3)
                {
                    lettersConfigs.Add(newWord, newLettersConfigs);
                }
            }
        }

        private void FindVerticalWords(List<List<string>> gridConfig)
        {
            throw new NotImplementedException();
        }
    }

    public class LetterConfig
    {
        public string Letter { get; } 
        public int RowIndex{ get; } 
        public int ColumnIndex{ get; } 

        public LetterConfig(string letter, int rowIndex, int columnIndex)
        {
            Letter = letter;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}