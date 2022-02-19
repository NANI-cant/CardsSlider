using UnityEngine;
using Zenject;

public class LocalizationInstaller : MonoInstaller {
    [SerializeField] private Localization localizationTemplate;

    public override void InstallBindings() {
        Localization localizationInstance = Container.InstantiatePrefabForComponent<Localization>(localizationTemplate,
            Vector3.zero,
            Quaternion.identity, this.transform);
        localizationInstance.Initialize();

        Container.Bind<Localization>().FromInstance(localizationInstance).AsSingle().NonLazy();
    }
}