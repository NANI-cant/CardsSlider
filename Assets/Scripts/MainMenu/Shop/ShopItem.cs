using System;
using UnityEngine;

namespace StartMenu {
    public enum ShopItemCondition {
        Buyable,
        NotEnoughMoney,
        UnSelected,
        Selected,
    }

    public class ShopItem : MonoBehaviour, IBuyable, ISelectable {
        public event Action<ShopItemCondition> ConditionChanged;

        private ItemData _itemData;
        private Bank _bank;
        private FigureCollectionsHolder _collectionsHolder;
        private PlayerProgress _progress;
        private ShopItemCondition _condition;

        public ItemData ItemData => _itemData;

        public void Construct(Bank bank, FigureCollectionsHolder figureCollectionsHolder, PlayerProgress progress, ItemData itemData) {
            _bank = bank;
            _collectionsHolder = figureCollectionsHolder;
            _progress = progress;
            _itemData = itemData;
        }

        private void OnEnable() {
            _collectionsHolder.CollectionChanged += OnCollectionChanged;
        }

        private void OnDisable() {
            _collectionsHolder.CollectionChanged -= OnCollectionChanged;
        }

        private void Start() {
            if (_itemData.IsAvailable) {
                _progress.SetShopItemAvailable(_itemData);
            }
            _itemData.IsAvailable = _progress.IsShopItemAvailable(_itemData);

            SetStartCondition();
            ConditionChanged?.Invoke(_condition);
        }

        private void SetStartCondition() {
            if (_itemData.IsAvailable) {
                if (_collectionsHolder.SelectedCollection == _itemData.FiguresCollection) {
                    _condition = ShopItemCondition.Selected;
                    return;
                }

                _condition = ShopItemCondition.UnSelected;
                return;
            }

            if (_bank.Amount < _itemData.BasePrice) {
                _condition = ShopItemCondition.NotEnoughMoney;
                return;
            }

            _condition = ShopItemCondition.Buyable;
        }

        public void Buy() {
            if (!CheckCanBeBuyedFor(_bank.Amount)) return;
            if (!_bank.TryToSpend(_itemData.BasePrice)) return;

            _progress.SetShopItemAvailable(_itemData);
            _itemData.IsAvailable = true;

            _condition = ShopItemCondition.UnSelected;
            ConditionChanged?.Invoke(_condition);
        }

        public void Select() {
            _collectionsHolder.SelectCollection(_itemData.FiguresCollection);

            _condition = ShopItemCondition.Selected;
            ConditionChanged?.Invoke(_condition);
        }

        private bool CheckCanBeBuyedFor(int amount) {
            if (_itemData.IsAvailable) return false;
            if (amount >= _itemData.BasePrice) return true;
            return false;
        }

        private void OnCollectionChanged(FiguresCollection obj) {
            if (_condition == ShopItemCondition.Selected) _condition = ShopItemCondition.UnSelected;
            ConditionChanged?.Invoke(_condition);
        }
    }
}
