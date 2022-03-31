using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StartMenu {
    public class ShopItemView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _nameUGUI;
        [SerializeField] private TextMeshProUGUI _priceUGUI;
        [SerializeField] private Image _image;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _selectButton;

        private void Awake() {
            _image.useSpriteMesh = true;
        }

        public void SetName(string name) {
            _nameUGUI.text = name;
        }

        public void SetPrice(int price) {
            _priceUGUI.text = price.ToString();
        }

        public void SetImage(Sprite image) {
            _image.sprite = image;
        }

        public void SetAlreadyBuyed() {
            _buyButton.gameObject.SetActive(false);
            _selectButton.gameObject.SetActive(true);
            _priceUGUI.color = new Color(0, 0, 0, 0);
            _buyButton.interactable = true;
        }

        public void SetNotEnoughMoney() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _priceUGUI.color = Color.red;
            _buyButton.interactable = false;
        }

        public void SetBuyable() {
            _buyButton.gameObject.SetActive(true);
            _selectButton.gameObject.SetActive(false);
            _priceUGUI.color = Color.white;
            _buyButton.interactable = true;
        }
    }
}
