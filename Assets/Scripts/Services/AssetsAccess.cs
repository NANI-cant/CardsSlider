using System.Collections.Generic;
using UnityEngine;

public class AssetsAccess {
    private const string ItemsDatasetPath = "SavingUnits/ItemDatasets";

    private List<ItemData> _shopItemDataset;

    public List<ItemData> ShopItemDataset => _shopItemDataset;

    public AssetsAccess() {
        _shopItemDataset = new List<ItemData>(Resources.LoadAll<ItemData>(ItemsDatasetPath));
    }
}