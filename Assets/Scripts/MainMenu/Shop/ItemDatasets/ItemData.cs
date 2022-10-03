using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/Shop/ItemData")]
public class ItemData : ScriptableObject {
    [SerializeField] private ItemId _id;
    [SerializeField] public bool IsAvailable;
    [SerializeField][Min(0)] private int _basePrice;
    [SerializeField] private FiguresCollection _figuresCollection;
    [SerializeField] private Sprite _icon;

    public ItemId Id => _id;
    public int BasePrice => _basePrice;
    public FiguresCollection FiguresCollection => _figuresCollection;
    public Sprite Icon => _icon;
}
