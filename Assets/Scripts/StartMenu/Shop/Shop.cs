using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StartMenu {
    public class Shop : MonoBehaviour {
        [SerializeField] private ShopItem _shopItemTemplate;
        [SerializeField] private Vector2 _itemsStart;
        [SerializeField] private float _offsetBetweenItems;

        [Header("Debug")]
        [SerializeField] RectTransform _shopItemRectTransform;

        private List<ItemData> _itemsData;
        private List<ShopItem> _itemsInstances = new List<ShopItem>();

        private Fabric _fabric;

        private Vector2 ItemsStartGlobal => transform.TransformPoint(_itemsStart);

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
                    ItemsStartGlobal + new Vector2(i * _offsetBetweenItems, 0),
                    transform);
                _itemsInstances.Add(shopItem);
            }
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.white;
            float width = _shopItemRectTransform.rect.width * GetComponent<RectTransform>().localScale.x;
            float height = _shopItemRectTransform.rect.height * GetComponent<RectTransform>().localScale.x;
            Vector3 size = new Vector3(width, height, 0f);

            for (int i = 0; i < 3; i++) {
                Gizmos.DrawWireCube(ItemsStartGlobal + new Vector2(i * _offsetBetweenItems, 0), size);
            }
        }
    }
}
