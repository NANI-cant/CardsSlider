using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StartMenu {
    [RequireComponent(typeof(ShopItemView))]
    public class ShopItem : MonoBehaviour, IBuyable, ISelectable {
        [SerializeField] private bool _isBase = false;
        [SerializeField] private int _id;
        [SerializeField] private string _localizationName;
        [SerializeField] private int _price;
        [SerializeField] private FiguresBank _figuresBank;
        [SerializeField] private Sprite _image;

        [Inject] private Bank _bank;
        [Inject] private FigureCollectionsHolder _banksHolder;

        private bool _isBuyed;
        private ShopItemView _view;

#if UNITY_EDITOR
        [SerializeField] private string DebugSaveKey;
        public bool IsBase => _isBase;
        public int Id => _id;

        private void OnValidate() {
            if (_price < 0) _price = 0;
            if (_id < 0) _id = 0;
            if (_id > SaveKey.ShopItemsId.Length - 1) _id = SaveKey.ShopItemsId.Length - 1;
            DebugSaveKey = SaveKey.ShopItemsId[_id];
        }
#endif

        private void Awake() {
            _view = GetComponent<ShopItemView>();
            if (IsBase) {
                new PlayerPrefs().SetBool(SaveKey.ShopItemsId[_id], true);
            }
        }

        private void OnEnable() {
            _bank.OnEarn += UpdateStateOverBank;
            _bank.OnSpend += UpdateStateOverBank;
        }

        private void OnDisable() {
            _bank.OnEarn -= UpdateStateOverBank;
            _bank.OnSpend -= UpdateStateOverBank;
        }

        private void Start() {
            _view.SetName(_localizationName);
            _view.SetPrice(_price);
            _view.SetImage(_image);

            _isBuyed = new PlayerPrefs().GetBool(SaveKey.ShopItemsId[_id], false);

            UpdateStateOverBank(_bank.Amount);
        }

        public void Buy() {
            if (!CheckCanBeBuyedFor(_bank.Amount)) return;
            if (!_bank.TryToSpend(_price)) return;

            new PlayerPrefs().SetBool(SaveKey.ShopItemsId[_id], true);
            _isBuyed = true;
            _view.SetAlreadyBuyed();

            Debug.Log(this + " Buyed");
        }

        public void Select() {
            _banksHolder.SelectBank(_figuresBank);
            Debug.Log(this + " Selected");
        }

        private void UpdateStateOverBank(int bankCurrentAmount) {
            if (CheckCanBeBuyedFor(bankCurrentAmount)) {
                _view.SetBuyable();
            }
            else if (_isBuyed) {
                _view.SetAlreadyBuyed();
            }
            else {
                _view.SetNotEnoughMoney();
            }
        }

        private bool CheckCanBeBuyedFor(int amount) {
            if (_isBuyed) return false;
            if (amount >= _price) return true;
            return false;
        }

    }
}
