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
            
            FindWordsInGrid(gridConfig, true);
            FindWordsInGrid(gridConfig, false);
            
            foreach (var key in lettersConfigs.Keys)
            {
              Debug.Log($"Words: {key}");  
            }
        }

        private void FindWordsInGrid(List<List<string>> gridConfig, bool isHorisontal)
        {
            for (int i = 0; i < gridConfig.Count; i++)
            {
                List<LetterConfig> newLettersConfigs = new List<LetterConfig>();
                string newWord = String.Empty;

                for (int j = 0; j < gridConfig[i].Count; j++)
                {
                    string trimmedLetter = isHorisontal ? gridConfig[i][j].Trim() : gridConfig[j][i].Trim();

                    if (trimmedLetter.IsEmpty())
                    {
                        if (newWord.Length < MIN_WORD_LENGTH)
                        {
                            newLettersConfigs.Clear();
                            newWord = String.Empty;
                        }
                        continue;
                    }

                    LetterConfig newLetter = new LetterConfig(trimmedLetter, i, j);
                    newLettersConfigs.Add(newLetter);
                    newWord += trimmedLetter;
                }

                AddWordToDictionary(newWord, newLettersConfigs);
            }
        }

        private void AddWordToDictionary(string newWord, List<LetterConfig> newLettersConfigs)
        {
            if (newWord.Length >= MIN_WORD_LENGTH)
            {
                lettersConfigs.Add(newWord, newLettersConfigs);
            }  
        }
    }
}
    
