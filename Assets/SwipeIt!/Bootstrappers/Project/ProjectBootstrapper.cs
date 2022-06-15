using System;
using UnityEngine;
using Zenject;

public class ProjectBootstrapper : MonoInstaller {
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private TextAsset _localizationXML;

    private Localization _localization;
    private PlayerProgress _playerProgress;
    private AssetsAccess _assetsAccess;

    public override void InstallBindings() {
        _localization = new Localization(_localizationXML, _gameSettings);
        _playerProgress = new PlayerProgress();
        _assetsAccess = new AssetsAccess();

        BindInstanceSingle<Localization>(_localization);
        BindInstanceSingle<GameSettings>(_gameSettings);
        BindInstanceSingle<PlayerProgress>(_playerProgress);
        BindInstanceSingle<AssetsAccess>(_assetsAccess);
    }

    private T BindInstanceSingle<T>(T instance) {
        Container
            .BindInstance<T>(instance)
            .AsSingle()
            .NonLazy();

        return instance;
    }

}