using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DragerInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<CardDragger>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
