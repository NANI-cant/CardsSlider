using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
#if UNITY_EDITOR
    [ContextMenu("GetAll")]
    public void GetAll() {
        foreach (string key in SaveKey.ShopItemsId) {
            PlayerPrefs.SetInt(key, 1);
        }
    }

    [ContextMenu("SoldAll")]
    public void SoldAll() {
        foreach (string key in SaveKey.ShopItemsId) {
            PlayerPrefs.DeleteKey(key);
        }
    }
#endif
}
