using System;
using System.Collections.Generic;
using System.Linq;
using WordAlgorithm.Configs;

namespace WordAlgorithm.GamePanels
{
    public class GamePanelChecker
    {
        public event Action FailInput;
        public event Action<List<LetterConfig>> OnWinInput;
        
        public void CheckStrings(string input, GamePanelView gamePanelView)
        {
            List<LetterConfig> inputWordConfig = new List<LetterConfig>();

            for (int j = 0; j < gamePanelView.WordOrganizer.LettersConfigs.Keys.Count; j++)
            {
                string key =  gamePanelView.WordOrganizer.LettersConfigs.ElementAt(j).Key;
                bool isEqual = string.Equals(key, input, StringComparison.OrdinalIgnoreCase);
                if (isEqual)
                {
                    gamePanelView.WordOrganizer.LettersConfigs.TryGetValue(key, out inputWordConfig);
                }
            }

            SelectSutableAction(inputWordConfig);
        }

        private void SelectSutableAction(List<LetterConfig> inputWordConfig)
        {
            if (inputWordConfig.Count > 0)
            {
                OnWinInput?.Invoke(inputWordConfig);
            }
            else
            {
                FailInput?.Invoke(); 
            }
        }
    }
}