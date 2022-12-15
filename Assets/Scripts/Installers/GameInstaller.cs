using UnityEngine;
using WordAlgorithm.GamePanels;
using WordAlgorithm.Interfaces;
using WordAlgorithm.Utilities;
using Zenject;

namespace WordAlgorithm.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GamePanelView gamePanelView;
        public override void InstallBindings()
        {
            Container.Bind<ILoadConfig>().To<ConfigLoader>().AsSingle().NonLazy();
            Container.Bind<IWordOrganizer>().To<WordOrganizer>().AsSingle().NonLazy();
            Container.Bind<GamePanelView>().FromInstance(gamePanelView).AsSingle().NonLazy();
        }
    }
}
