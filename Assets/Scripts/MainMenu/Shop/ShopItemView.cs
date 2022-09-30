using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

namespace StartMenu {
    public class ShopItemView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _nameUGUI;
        [SerializeField] private TextMeshProUGUI _priceUGUI;
        [SerializeField] private SVGImage _image;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private SVGImage _selectedLabel;

        private ShopItem _model;
        //private Bank _bank;
        //private FigureCollectionsHolder _collectionsHolder;

        public void Construct(ShopItem model, Bank bank, FigureCollectionsHolder collectionsHolder) {
            _model = model;
            //_bank = bank;
            //_collectionsHolder = collectionsHolder;
        }

        private void OnEnable() {
            _model.ConditionChanged += UpdateUI;
            //_bank.OnEarn += OnBankChangeAmount;
            //_bank.OnSpend += OnBankChangeAmount;

            _buyButton.onClick.AddListener(_model.Buy);
            _selectButton.onClick.AddListener(_model.Select);
        }

        private void OnDisable() {
            _model.ConditionChanged -= UpdateUI;
            //_bank.OnEarn -= OnBankChangeAmount;
            //_bank.OnSpend -= OnBankChangeAmount;

            _buyButton.onClick.RemoveListener(_model.Buy);
            _selectButton.onClick.RemoveListener(_model.Select);
        }

        private void Start() {
            _nameUGUI.text = _model.ItemData.LocalizationKey;
            _priceUGUI.text = _model.ItemData.BasePrice.ToString();
            _image.sprite = _model.ItemData.Icon;
        }

        private void UpdateUI(ShopItemCondition condition) {
            switch (condition) {
                case ShopItemCondition.Buyable: {
                        SetBuyable();
                        break;
                    }
                case ShopItemCondition.NotEnoughMoney: {
                        SetNotEnoughMoney();
                        break;
                    }
                case ShopItemCondition.UnSelected: {
                        SetUnSelected();
                        break;
                    }
                case ShopItemCondition.Selected: {
                        SetSelected();
                        break;
                    }
            }

            // if (_model.ItemData.IsAvailable) {
            //     if (_collectionsHolder.SelectedCollection == _model.ItemData.FiguresCollection) {
            //         SetSelected();
            //         return;
            //     }

            //     SetUnSelected();
            //     return;
            // }

            // if (_bank.Amount < _model.ItemData.BasePrice) {
            //     SetNotEnoughMoney();
            //     return;
            // }

            // SetBuyable();
        }

        private void SetUnSelected() {
            _buyButton.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
            _selectedLabel.gameObject.SetActive(false);
            _priceUGUI.color = new Color(0, 0, 0, 0);
            _buyButton.interactable = false;
        }

        private void SetNotEnoughMoney() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _selectedLabel.gameObject.SetActive(false);
            _priceUGUI.color = Color.red;
            _buyButton.interactable = false;
        }

        private void SetBuyable() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _selectedLabel.gameObject.SetActive(false);
            _priceUGUI.color = Color.black;
            _buyButton.interactable = true;
        }

        private void SetSelected() {
            _buyButton.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(false);
            _selectedLabel.gameObject.SetActive(true);
            _priceUGUI.color = new Color(0, 0, 0, 0);
            _buyButton.interactable = false;
        }

        //private void OnBankChangeAmount(int amount) => UpdateUI();
    }
}
