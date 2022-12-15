using System;
using UnityEngine;

namespace WordAlgorithm
{
    public class GameManager : MonoBehaviour
    {
        private const string TEST_LEVEl_CONFIG_NAME = "WordsConfig_1";
        
        [SerializeField] private StartPanel startPanel;
        [SerializeField] private GamePanel gamePanel;

        public WordOrganizer Organizer { get; private set; }

        private void OnEnable()
        {
            startPanel.StartGame += LoadGameConfig;
        }

        private async void LoadGameConfig()
        {
            var configLoader = new ConfigLoader();
            GridConfig levelConfig = await configLoader.LoadConfigByName(TEST_LEVEl_CONFIG_NAME);
            Debug.Log($"Level  config: {levelConfig.failReaction}");
            
            gamePanel.Init(levelConfig);
            //TODO: make organizer as separate injected class
            Organizer = new WordOrganizer();
            Organizer.OrganizeWordList(levelConfig.grid);
            //from grid config create list with words, and with letters and coordinates,
            //find vertical words and horizontal

        }
    }
}
