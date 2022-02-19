using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<Game>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}