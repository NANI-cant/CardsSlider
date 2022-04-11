using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace StartMenu {
    public class ShopItem : MonoBehaviour, IBuyable, ISelectable {
        [SerializeField] private ItemData _itemData;

        public UnityAction ConditionChanged;

        private Bank _bank;
        private FigureCollectionsHolder _banksHolder;
        private PlayerProgress _progress;

        public ItemData ItemData => _itemData;

        [Inject]
        public void Construct(Bank bank, FigureCollectionsHolder figureCollectionsHolder, PlayerProgress progress) {
            _bank = bank;
            _banksHolder = figureCollectionsHolder;
            _progress = progress;
        }

        private void Awake() {
            if (_itemData.IsAvailable) {
                _progress.SetShopItemAvailable(_itemData);
            }
            _itemData.IsAvailable = _progress.IsShopItemAvailable(_itemData);
        }

        private void Start() {
            ConditionChanged?.Invoke();
        }

        public void Buy() {
            if (!CheckCanBeBuyedFor(_bank.Amount)) return;
            if (!_bank.TryToSpend(_itemData.BasePrice)) return;

            _progress.SetShopItemAvailable(_itemData);
            _itemData.IsAvailable = true;

            ConditionChanged?.Invoke();
            Debug.Log(this + " Buyed");
        }

        public void Select() {
            _banksHolder.SelectBank(_itemData.FiguresCollection);
            Debug.Log(this + " Selected");
        }

        private bool CheckCanBeBuyedFor(int amount) {
            if (_itemData.IsAvailable) return false;
            if (amount >= _itemData.BasePrice) return true;
            return false;
        }
    }
}
