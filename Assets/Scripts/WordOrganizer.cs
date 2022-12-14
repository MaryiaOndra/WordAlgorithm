using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace WordAlgorithm
{
    public class WordOrganizer
    {
        private const int MIN_WORD_LENGTH = 3;

        private Dictionary<string, List<LetterConfig>> lettersConfigs;
        
        public void OrganizeWordList(List<List<string>> gridConfig)
        {
            lettersConfigs = new Dictionary<string, List<LetterConfig>>();
            
            FindHorizontalWords(gridConfig);
            FindVerticalWords(gridConfig);
            
            Debug.Log("KEYS: " +  lettersConfigs.Keys.Count);
            
            foreach (var key in lettersConfigs.Keys)
            {
              Debug.Log($"Words: {key}");  
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
                   
                    if (trimmedLetter.IsEmpty())
                    {
                        if (!newWord.IsEmpty() && (newWord.Length < MIN_WORD_LENGTH))
                        {
                            Debug.Log("CLEAR");
                            newLettersConfigs.Clear();
                            newWord = String.Empty;
                        }
                        Debug.Log("CONTINUE");
                        continue;
                    }


                    LetterConfig newLetter = new LetterConfig( trimmedLetter,i, j);
                    newLettersConfigs.Add(newLetter);
                    Debug.Log("ADD LETTER:" + newLetter);
                    newWord += trimmedLetter;
                    Debug.Log("ADD WORD LETTER:" + newWord);
                }
                
                Debug.Log("NEW WORD:" + newWord);

                if (newWord.Length >= MIN_WORD_LENGTH)
                {
                    lettersConfigs.Add(newWord, newLettersConfigs);
                }
            }
        }

        private void FindVerticalWords(List<List<string>> gridConfig)
        {
            for (int i = 0; i < gridConfig.Count; i++)
            {
                List<LetterConfig> newLettersConfigs = new List<LetterConfig>();
                string newWord = String.Empty;
                
                for (int j = 0; j < gridConfig.Count; j++)
                {
                    var trimmedLetter = gridConfig[j][i].Trim();
                    
                    if (trimmedLetter.IsEmpty())
                    {
                        if (newWord.Length < MIN_WORD_LENGTH)
                        {
                            newLettersConfigs.Clear();
                            newWord = String.Empty;
                        }
                        continue;
                    }

                    LetterConfig newLetter = new LetterConfig( trimmedLetter,i, j);
                    newLettersConfigs.Add(newLetter);
                    newWord += trimmedLetter;
                }
                
                if (newWord.Length >= MIN_WORD_LENGTH)
                {
                    lettersConfigs.Add(newWord, newLettersConfigs);
                }
            }
        }
    }
    
    public struct LetterConfig
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