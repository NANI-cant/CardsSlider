using UnityEngine;
using Zenject;

public class FiguresCollectionsHolderInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container
            .Bind<FigureCollectionsHolder>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}