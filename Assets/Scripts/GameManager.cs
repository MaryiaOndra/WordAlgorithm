using System;
using UnityEngine;

namespace WordAlgorithm
{
    public class GameManager : MonoBehaviour
    {
        private const string TEST_LEVEl_CONFIG_NAME = "WordsConfig_1";
        
        [SerializeField] private StartPanel startPanel;
        [SerializeField] private GamePanel gamePanel;

        private void OnEnable()
        {
            startPanel.StartGame += LoadGameConfig;
        }

        private void LoadGameConfig()
        {
            var configLoader = new ConfigLoader();
            GridConfig levelConfig = configLoader.LoadConfigByName(TEST_LEVEl_CONFIG_NAME);
            gamePanel.Init(levelConfig);
            //from grid config create list with words, and with letters and coordinates,
            //find vertical words and horizontal
        }
    }
}
