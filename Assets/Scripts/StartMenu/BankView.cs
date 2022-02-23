using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartMenu {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BankView : MonoBehaviour {
        private TextMeshProUGUI _uGUI;

        [Inject] private Bank _bankModel;

        private void Awake() {
            _uGUI = GetComponent<TextMeshProUGUI>();
        }

        private void Start() {
            ChangeUI(_bankModel.Amount);
        }

        private void OnEnable() {
            _bankModel.OnEarn += ChangeUI;
            _bankModel.OnSpend += ChangeUI;
        }

        private void OnDisable() {
            _bankModel.OnEarn -= ChangeUI;
            _bankModel.OnSpend -= ChangeUI;
        }

        private void ChangeUI(int amount) {
            _uGUI.text = amount.ToString();
        }
    }
}
