using UnityEngine;

namespace StartMenu {
    public class Bank : MonoBehaviour {
        [SerializeField] private BankView _view;

        private int _amount;

        public int Amount => _amount;

        private void Awake() {
            _amount = PlayerPrefs.GetInt(SaveKey.Bank, 0);
        }

        private void Start() {
            _view.ChangeUI(_amount);
        }

        public bool CanSpend(int total) {
            return _amount >= total;
        }

        public bool TryToSpend(int total) {
            if (!CanSpend(total)) return false;

            _amount -= total;
            PlayerPrefs.SetInt(SaveKey.Bank, _amount);
            _view.ChangeUI(_amount);
            return true;
        }

        public void Earn(int total) {
            _amount += total;
            PlayerPrefs.SetInt(SaveKey.Bank, _amount);
            _view.ChangeUI(_amount);
        }
    }
}

