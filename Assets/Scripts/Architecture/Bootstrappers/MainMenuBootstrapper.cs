using System;
using UnityEngine;
using Zenject;

namespace StartMenu {
    public class MainMenuBootstrapper : MonoInstaller {
        [SerializeField] private Bank _bank;
        [SerializeField] private FigureCollectionsHolder _figureCollectionsHolder;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private GameModePanel _gameModePanel;
        [SerializeField] private SwipeHandler _swipeHandler;

        private ShopItemFactory _shopItemFactory;
        private PlayerProgress _playerProgress;
        private IInputService _inputService;

        [Inject]
        public void Construct(PlayerProgress playerProgress) {
            _playerProgress = playerProgress;
        }

        public override void InstallBindings() {
            _shopItemFactory = new ShopItemFactory(_bank, _figureCollectionsHolder, _playerProgress);
            _inputService = new PointerInput();

            BindInstanceSingle<IInputService>(_inputService);
            BindInstanceSingle<ShopItemFactory>(_shopItemFactory);
            BindInstanceSingle<Bank>(_bank);
            BindInstanceSingle<FigureCollectionsHolder>(_figureCollectionsHolder);
            BindInstanceSingle<Camera>(_mainCamera);
            BindInstanceSingle<GameModePanel>(_gameModePanel);
            BindInstanceSingle<SwipeHandler>(_swipeHandler);
        }

        private void OnDestroy() {
            (_inputService as IDisposable).Dispose();
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