using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StartMenu {
    public class DEBUGManager : MonoBehaviour {
        [ContextMenu("Clear All Prefs")]
        public void ClearAllPrefs() {
            PlayerPrefs.DeleteAll();
        }
    }
}
