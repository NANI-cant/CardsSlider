using UnityEngine;

public class DebugManager : MonoBehaviour {
    [ContextMenu("Destroy All Cards")]
    private void DestroyAllCards() {
        Card[] cards = FindObjectsOfType<Card>();
        foreach (var card in cards) {
            card.Destroy();
        }
    }
}
