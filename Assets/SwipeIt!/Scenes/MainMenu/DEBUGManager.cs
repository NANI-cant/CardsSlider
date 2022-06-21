using System.Collections.Generic;
using UnityEngine;

namespace StartMenu {
    public class DEBUGManager : MonoBehaviour {
        [ContextMenu("Clear All Prefs")]
        public void ClearAllPrefs() {
            PlayerPrefs.DeleteAll();
        }

        [ContextMenu("SoldAllItems")]
        public void SoldAllItems() {
            ItemData[] itemsDataset = Resources.FindObjectsOfTypeAll<ItemData>();
            foreach (var item in itemsDataset) {
                item.IsAvailable = false;
            }
            ClearAllPrefs();
        }
    }
}
