using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StartMenu {
    public class Shop : MonoBehaviour {
        [SerializeField] private ShopItem _shopItemTemplate;
        [SerializeField] private Transform _parentTransform;
        
        [Header("Debug")]
        [SerializeField] RectTransform _shopItemRectTransform;

        private List<ItemData> _itemsData;
        private List<ShopItem> _itemsInstances = new List<ShopItem>();

        private Fabric _fabric;


        [Inject]
        public void Construct(AssetsAccess assetsAccess, Fabric fabric) {
            _itemsData = assetsAccess.ShopItemDataset;
            _fabric = fabric;
        }

        private void Start() {
            CreateShopItems(_itemsData);
        }

        private void CreateShopItems(List<ItemData> itemsData) {
            for (int i = 0; i < _itemsData.Count; i++) {
                ShopItem shopItem = _fabric.InstantiateShopItem(
                    _shopItemTemplate,
                    _itemsData[i],
                    _parentTransform);
                _itemsInstances.Add(shopItem);
            }
        }
    }
}
