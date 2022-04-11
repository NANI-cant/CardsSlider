using System.Collections.Generic;
using System.Linq;
using StartMenu;
using UnityEditor;
using UnityEngine;


public class CustomTools : ScriptableWizard {
    [MenuItem("CustomTools/ValidateBanks #&f")]
    static void ValidateBanks() {
        Debug.Log("Figures banks validation: start");
        bool isOK = true;
        List<FiguresBank> banks = new List<FiguresBank>(Resources.FindObjectsOfTypeAll<FiguresBank>());
        banks = new List<FiguresBank>(banks.OrderBy(b => b.Id));

        for (int i = 0; i < banks.Count - 1; i++) {
            if (banks[i].Id == banks[i + 1].Id) {
                Debug.LogError(banks[i] + " and " + banks[i + 1] + " have same Id");
                isOK = false;
            }
        }

        if (isOK) {
            Debug.Log("Figures banks validation: success");
        }
        else {
            Debug.LogError("Figures banks validation: failure, check console logs");
        }
    }

    // [MenuItem("CustomTools/ValidateShopItems #&s")]
    // static void ValidateShopItems() {
    //     Debug.Log("Shop items validation: start");
    //     bool isOK = true;
    //     List<ShopItem> items = new List<ShopItem>(FindObjectsOfType<ShopItem>());
    //     items = new List<ShopItem>(items.OrderBy(it => it.Id));

    //     for (int i = 0; i < items.Count - 1; i++) {
    //         if (items[i].Id == items[i + 1].Id) {
    //             Debug.LogError(items[i] + " and " + items[i + 1] + " have same Id");
    //             isOK = false;
    //         }
    //     }

    //     int baseCount = items.Count(si => si.IsBase);
    //     if (baseCount == 0) {
    //         isOK = false;
    //         Debug.LogError("0 base shop item, must be 1");
    //     }
    //     else if (baseCount > 1) {
    //         isOK = false;
    //         Debug.LogError(">1 base shop item, must be 1");
    //     }

    //     if (isOK) {
    //         Debug.Log("Shop items validation: success");
    //     }
    //     else {
    //         Debug.LogError("Shop items validation: failure, check console logs");
    //     }
    // }
}
