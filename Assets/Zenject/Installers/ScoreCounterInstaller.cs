using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreCounterInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<ScoreCounter>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}
