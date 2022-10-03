using StartMenu;
using UnityEngine;

public class ShopItemFactory {
    private Bank _bank;
    private FigureCollectionsHolder _figureCollectionHolder;
    private PlayerProgress _playerProgress;

    public ShopItemFactory(Bank bank, FigureCollectionsHolder figureCollectionsHolder, PlayerProgress playerProgress) {
        _bank = bank;
        _figureCollectionHolder = figureCollectionsHolder;
        _playerProgress = playerProgress;
    }

    public ShopItem InstantiateShopItem(ShopItem template, ItemData itemData, Transform parent) {
        template.gameObject.SetActive(false);
        ShopItem instance = GameObject.Instantiate(template, parent);
        template.gameObject.SetActive(true);

        instance.Construct(_bank, _figureCollectionHolder, _playerProgress, itemData);
        instance.GetComponent<ShopItemView>().Construct(instance, _bank, _figureCollectionHolder);
        instance.gameObject.SetActive(true);
        return instance;
    }
}