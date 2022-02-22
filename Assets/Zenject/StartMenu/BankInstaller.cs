using StartMenu;
using UnityEngine;
using Zenject;

public class BankInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container
            .Bind<Bank>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}