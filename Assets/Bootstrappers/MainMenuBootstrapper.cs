using UnityEngine;
using Zenject;

namespace StartMenu {
    public class MainMenuBootstrapper : MonoInstaller {
        [SerializeField] private Bank _bank;
        [SerializeField] private FigureCollectionsHolder _figureCollectionsHolder;

        public override void InstallBindings() {
            BindInstanceSingle<Bank>(_bank);
            BindInstanceSingle<FigureCollectionsHolder>(_figureCollectionsHolder);
        }

        private T BindInstanceSingle<T>(T instance) {
            Container
                .BindInstance<T>(instance)
                .AsSingle()
                .NonLazy();
            return instance;
        }
    }
}