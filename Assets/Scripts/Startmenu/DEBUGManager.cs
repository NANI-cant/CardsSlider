using UnityEngine;

namespace StartMenu {
    public class DEBUGManager : MonoBehaviour {
        [ContextMenu("Clear All Prefs")]
        public void ClearAllPrefs() {
            PlayerPrefs.DeleteAll();
        }
    }
}
