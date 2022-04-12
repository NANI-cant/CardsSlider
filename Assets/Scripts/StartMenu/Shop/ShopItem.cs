using UnityEngine;
using UnityEngine.Events;

namespace StartMenu {
    public class ShopItem : MonoBehaviour, IBuyable, ISelectable {
        public UnityAction ConditionChanged;

        private ItemData _itemData;
        private Bank _bank;
        private FigureCollectionsHolder _banksHolder;
        private PlayerProgress _progress;

        public ItemData ItemData => _itemData;

        public void Construct(Bank bank, FigureCollectionsHolder figureCollectionsHolder, PlayerProgress progress, ItemData itemData) {
            _bank = bank;
            _banksHolder = figureCollectionsHolder;
            _progress = progress;
            _itemData = itemData;
        }

        private void Start() {
            if (_itemData.IsAvailable) {
                _progress.SetShopItemAvailable(_itemData);
            }
            _itemData.IsAvailable = _progress.IsShopItemAvailable(_itemData);
            ConditionChanged?.Invoke();
        }

        public void Buy() {
            if (!CheckCanBeBuyedFor(_bank.Amount)) return;
            if (!_bank.TryToSpend(_itemData.BasePrice)) return;

            _progress.SetShopItemAvailable(_itemData);
            _itemData.IsAvailable = true;

            ConditionChanged?.Invoke();
        }

        public void Select() {
            _banksHolder.SelectBank(_itemData.FiguresCollection);
        }

        private bool CheckCanBeBuyedFor(int amount) {
            if (_itemData.IsAvailable) return false;
            if (amount >= _itemData.BasePrice) return true;
            return false;
        }
    }
}
