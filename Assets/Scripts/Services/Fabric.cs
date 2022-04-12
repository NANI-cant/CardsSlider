using StartMenu;
using UnityEngine;

public class Fabric {
    private Bank _bank;
    private FigureCollectionsHolder _figureCollectionHolder;
    private PlayerProgress _playerProgress;

    public Fabric(Bank bank, FigureCollectionsHolder figureCollectionsHolder, PlayerProgress playerProgress) {
        _bank = bank;
        _figureCollectionHolder = figureCollectionsHolder;
        _playerProgress = playerProgress;
    }

    public ShopItem InstantiateShopItem(ShopItem template, ItemData itemData, Vector2 position, Transform parent) {
        template.gameObject.SetActive(false);
        ShopItem instance = GameObject.Instantiate(template, position, Quaternion.identity, parent);
        template.gameObject.SetActive(true);
        
        instance.Construct(_bank, _figureCollectionHolder, _playerProgress, itemData);
        instance.GetComponent<ShopItemView>().Construct(_bank);
        instance.gameObject.SetActive(true);
        return instance;
    }
}