using UnityEngine;
using Zenject;

public class FigureGeneratorInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<FigureGenerator>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}