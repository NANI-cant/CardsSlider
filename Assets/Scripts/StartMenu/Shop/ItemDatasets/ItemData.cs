using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Shop/ItemData")]
public class ItemData : ScriptableObject {
    [SerializeField] private ItemId _id;
    [SerializeField] public bool IsAvailable;
    [SerializeField] private string _localizationKey;
    [Min(0)]
    [SerializeField] private int _basePrice;
    [SerializeField] private FiguresBank _figuresCollection;
    [SerializeField] private Sprite _icon;

    public ItemId Id => _id;
    public string LocalizationKey => _localizationKey;
    public int BasePrice => _basePrice;
    public FiguresBank FiguresCollection => _figuresCollection;
    public Sprite Icon => _icon;
}
