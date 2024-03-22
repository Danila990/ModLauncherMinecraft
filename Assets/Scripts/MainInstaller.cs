using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private WindowController _windowController;

    public override void InstallBindings()
    {
        Container.Bind<WindowController>().FromInstance(_windowController).AsSingle().NonLazy();

        /*//Container.Bind<ConfigContainer>().FromNewScriptableObject(_config).AsSingle().NonLazy();

        Container.Bind<ResourcesLoader>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

        Container.Bind<TowerHealth>().FromInstance(_towerHealth).AsSingle().NonLazy();

        Container.Bind<UnitFactory>().FromComponentInNewPrefab(_unitFactory).AsSingle().NonLazy();

        Container.Bind<WaveController>().FromComponentInNewPrefab(_waveController).AsSingle().NonLazy();*/
    }
}
