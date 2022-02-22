using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FigureCollectionsHolder : MonoBehaviour {
    [SerializeField] private FiguresBank _defaultBank;

    private FiguresBank _selectedBank;

    public FiguresBank SelectedBank => _selectedBank;

    private void Awake() {
        if (PlayerPrefs.HasKey(SaveKey.SelectedFiguresBankId)) {
            int selectedId = PlayerPrefs.GetInt(SaveKey.SelectedFiguresBankId);
            FiguresBank[] _allBanks = Resources.FindObjectsOfTypeAll<FiguresBank>();

            foreach (var bank in _allBanks) {
                if (bank.Id == selectedId) {
                    _selectedBank = bank;
                    return;
                }
            }
        }

        _selectedBank = _defaultBank;
    }

    public void SelectBank(FiguresBank bank) {
        _selectedBank = bank;
        PlayerPrefs.SetInt(SaveKey.SelectedFiguresBankId, _selectedBank.Id);
    }

#if UNITY_EDITOR
    [ContextMenu("ForgotSelectedBank")]
    public void ForgotSelectedBank() {
        PlayerPrefs.DeleteKey(SaveKey.SelectedFiguresBankId);
    }
#endif
}
