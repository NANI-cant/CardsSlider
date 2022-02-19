using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StartMenu {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BankView : MonoBehaviour {
        private TextMeshProUGUI _uGUI;

        private void Awake() {
            _uGUI = GetComponent<TextMeshProUGUI>();
        }

        public void ChangeUI(int amount) {
            _uGUI.text = amount.ToString();
        }
    }
}
