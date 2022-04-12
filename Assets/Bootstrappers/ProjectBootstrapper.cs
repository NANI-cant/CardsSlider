using UnityEngine;
using Zenject;

public class ProjectBootstrapper : MonoInstaller {
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private TextAsset _localizationXML;

    private Localization _localization;
    private PlayerProgress _playerProgress;

    public override void InstallBindings() {
        _localization = new Localization(_localizationXML, _gameSettings);
        _playerProgress = new PlayerProgress();

        BindInstanceSingle<GameSettings>(_gameSettings);
        BindInstanceSingle<Localization>(_localization);
        BindInstanceSingle<PlayerProgress>(_playerProgress);
    }

    private T InstantiatePrefab<T>(T template) where T : MonoBehaviour {
        T templateInstance = Container.InstantiatePrefabForComponent<T>(
                template,
                Vector3.zero,
                Quaternion.identity,
                null);

        return templateInstance;
    }

    private T BindInstanceSingle<T>(T instance) {
        Container
            .BindInstance<T>(instance)
            .AsSingle()
            .NonLazy();

        return instance;
    }
}