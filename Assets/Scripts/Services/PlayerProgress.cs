using UnityEngine;

public class PlayerProgress {
    private readonly string Score = "Score";
    private readonly string Bank = "Bank";

    public void SaveBank(int newBank) {
        PlayerPrefs.SetInt(Bank, newBank);
    }

    public void AddBank(int value) {
        if (value <= 0) return;

        SaveBank(GetBank() + value);
    }

    public int GetBank() {
        return PlayerPrefs.GetInt(Bank, 0);
    }

    public bool TryUpdateScore(GameMode gameMode, int newScore, out int currentScore) {
        int oldScore = GetScore(gameMode);
        currentScore = Mathf.Max(oldScore, newScore);
        PlayerPrefs.SetInt(GameModeToKey(gameMode), currentScore);
        return oldScore < newScore;
    }

    public int GetScore(GameMode gameMode) {
        return PlayerPrefs.GetInt(GameModeToKey(gameMode), 0);
    }

    public void SetShopItemAvailable(ItemData itemData) {
        PlayerPrefs.SetInt(ItemIdToKey(itemData.Id), 1);
    }

    public bool IsShopItemAvailable(ItemData itemData) {
        return PlayerPrefs.HasKey(ItemIdToKey(itemData.Id));
    }


    private string GameModeToKey(GameMode mode) => mode.ToString() + Score;
    private string ItemIdToKey(ItemId id) => id.ToString();
}
