using UnityEngine;
using Zenject;

public class LifeCounterInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<LifeCounter>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}