using UnityEngine;
using Zenject;

public class TimerInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<Timer>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}