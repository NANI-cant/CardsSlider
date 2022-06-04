using UnityEngine;
using Zenject;

namespace StartMenu {
    public class DEBUGManager : MonoBehaviour {
        private Localization _localization;

        [Inject]
        public void Construct(Localization localization) {
            _localization = localization;
        }

        [ContextMenu("Clear All Prefs")]
        public void ClearAllPrefs() {
            PlayerPrefs.DeleteAll();
        }

        [ContextMenu("Change Language Random")]
        public void ChangeLanguageRandom() {
            _localization.ChangeLanguage(Random.Range(0, 2));
        }
    }
}
