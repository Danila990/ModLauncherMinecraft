using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private WindowController _windowController;
    [SerializeField] private LocalizationController _localizationController;

    public override void InstallBindings()
    {
        Container.Bind<WindowController>().FromInstance(_windowController).AsSingle().NonLazy();

        Container.Bind<LocalizationController>().FromInstance(_localizationController).AsSingle().NonLazy();
    }
}
