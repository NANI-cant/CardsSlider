using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace StartMenu {
    public class ShopItemView : MonoBehaviour {
        [SerializeField] private ShopItem _shopItem;
        [SerializeField] private TextMeshProUGUI _nameUGUI;
        [SerializeField] private TextMeshProUGUI _priceUGUI;
        [SerializeField] private Image _image;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;

        private Bank _bank;

        [Inject]
        public void Construct(Bank bank) {
            _bank = bank;
        }

        private void Awake() {
            _image.useSpriteMesh = true;
        }

        private void OnEnable() {
            _shopItem.ConditionChanged += UpdateUI;
            _bank.OnEarn += OnBankChangeAmount;
            _bank.OnSpend += OnBankChangeAmount;
            
            _buyButton.onClick.AddListener(_shopItem.Buy);
            _selectButton.onClick.AddListener(_shopItem.Select);
        }

        private void OnDisable() {
            _shopItem.ConditionChanged -= UpdateUI;
            _bank.OnEarn -= OnBankChangeAmount;
            _bank.OnSpend -= OnBankChangeAmount;

            _buyButton.onClick.RemoveListener(_shopItem.Buy);
            _selectButton.onClick.RemoveListener(_shopItem.Select);
        }

        private void Start() {
            _nameUGUI.text = _shopItem.ItemData.LocalizationKey;
            _priceUGUI.text = _shopItem.ItemData.BasePrice.ToString();
            _image.sprite = _shopItem.ItemData.Icon;
        }

        private void UpdateUI() {
            if (_shopItem.ItemData.IsAvailable) {
                SetAlreadyBuyed();
            }
            else if (_bank.Amount < _shopItem.ItemData.BasePrice) {
                SetNotEnoughMoney();
            }
            else {
                SetBuyable();
            }
        }

        private void SetAlreadyBuyed() {
            _buyButton.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
            _priceUGUI.color = new Color(0, 0, 0, 0);
            _buyButton.interactable = true;
        }

        private void SetNotEnoughMoney() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _priceUGUI.color = Color.red;
            _buyButton.interactable = false;
        }

        private void SetBuyable() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _priceUGUI.color = Color.white;
            _buyButton.interactable = true;
        }

        private void OnBankChangeAmount(int amount) => UpdateUI();
    }
}
