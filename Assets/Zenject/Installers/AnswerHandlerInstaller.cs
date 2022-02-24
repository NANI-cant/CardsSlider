using UnityEngine;
using Zenject;

public class AnswerHandlerInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container
            .Bind<AnswerHandler>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}