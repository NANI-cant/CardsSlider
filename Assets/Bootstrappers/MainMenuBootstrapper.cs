using UnityEngine;
using Zenject;

namespace StartMenu {
    public class MainMenuBootstrapper : MonoInstaller {
        [SerializeField] private Bank _bank;
        [SerializeField] private FigureCollectionsHolder _figureCollectionsHolder;

        private Fabric _fabric;
        private PlayerProgress _playerProgress;

        [Inject]
        public void Construct(PlayerProgress playerProgress) {
            _playerProgress = playerProgress;
        }

        public override void InstallBindings() {
            _fabric = new Fabric(_bank, _figureCollectionsHolder, _playerProgress);

            BindInstanceSingle<Fabric>(_fabric);
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