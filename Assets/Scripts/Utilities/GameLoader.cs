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
        
        [Inject] private StartPanel _startPanel;
        [Inject] private GamePanelView _gamePanelView;
        [Inject] private ILoadConfig _loadConfig;
        [Inject] private IWordOrganizer _wordOrganizer;
        
        private void OnEnable()
        {
            _startPanel.StartButtonPreessed += OnLoadGameProcess;
        }

        private void OnDisable()
        {
            _startPanel.StartButtonPreessed -= OnLoadGameProcess;
        }

        private async void OnLoadGameProcess()
        {
            GridConfig levelConfig = await _loadConfig.Load(configName);
            _wordOrganizer.OrganizeWordList(levelConfig.Grid);
            var gamePanelPresenter = new GamePanelPresenter(_gamePanelView, levelConfig);
            await Task.Delay(10);
            _startPanel.DisableScreen();
        }
    }
}
