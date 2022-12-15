using System.Threading.Tasks;
using UnityEngine;
using WordAlgorithm.GamePanels;
using WordAlgorithm.Interfaces;
using Zenject;

namespace WordAlgorithm.Utilities
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private string configName = "WordsConfig_1";
        [SerializeField] private StartPanel startPanel;
        [SerializeField] private GamePanelView gamePanelView;

        [Inject] private ILoadConfig _loadConfig;
        [Inject] private IWordOrganizer _wordOrganizer;
        
        private void OnEnable()
        {
            startPanel.StartGame += StartLoadingGameLevel;
        }

        private void OnDisable()
        {
            startPanel.StartGame -= StartLoadingGameLevel;
        }

        private async void StartLoadingGameLevel()
        {
            GridConfig levelConfig = await _loadConfig.Load(configName);
            _wordOrganizer.OrganizeWordList(levelConfig.Grid);
            gamePanelView.Init(levelConfig);
            await Task.Delay(10);
            startPanel.DisableScreen();
        }
    }
}
