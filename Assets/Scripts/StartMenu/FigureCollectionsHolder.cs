using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class FigureCollectionsHolder : MonoBehaviour {
    [SerializeField] private FiguresBank _defaultBank;

    public UnityAction<FiguresBank> OnBankChanged;

    private FiguresBank _selectedBank;

    public FiguresBank SelectedBank => _selectedBank;

    private void Awake() {
        if (PlayerPrefs.HasKey(SaveKey.SelectedFiguresBankId)) {
            int selectedId = PlayerPrefs.GetInt(SaveKey.SelectedFiguresBankId);
            FiguresBank[] allBanks = Resources.FindObjectsOfTypeAll<FiguresBank>();
            FiguresBank selectedBank = allBanks.FirstOrDefault(b => b.Id == selectedId);
            Assert.IsNotNull(selectedBank, "Saved id = " + selectedId + " cant be finded");
            SelectBank(selectedBank);
        }
        else {
            SelectBank(_defaultBank);
        }
    }

    public void SelectBank(FiguresBank bank) {
        _selectedBank = bank;
        PlayerPrefs.SetInt(SaveKey.SelectedFiguresBankId, _selectedBank.Id);
        OnBankChanged?.Invoke(_selectedBank);
    }

#if UNITY_EDITOR
    [ContextMenu("ForgotSelectedBank")]
    public void ForgotSelectedBank() {
        PlayerPrefs.DeleteKey(SaveKey.SelectedFiguresBankId);
    }
#endif
}
