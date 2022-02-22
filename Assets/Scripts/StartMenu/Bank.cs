using UnityEngine;
using UnityEngine.Events;

namespace StartMenu {
    public class Bank : MonoBehaviour {
        [SerializeField] private BankView _view;

        public UnityAction OnEarn;
        public UnityAction OnSpend;

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
            OnSpend?.Invoke();
            return true;
        }

        public void Earn(int total) {
            _amount += total;
            PlayerPrefs.SetInt(SaveKey.Bank, _amount);
            _view.ChangeUI(_amount);
            OnEarn?.Invoke();
        }

#if UNITY_EDITOR
        [ContextMenu("Earn10")]
        public void Earn10() => Earn(10);
        [ContextMenu("Earn100")]
        public void Earn100() => Earn(100);
        [ContextMenu("Earn1000")]
        public void Earn1000() => Earn(1000);

        [ContextMenu("Spend10")]
        public void Spend10() => TryToSpend(10);
        [ContextMenu("Spend100")]
        public void Spend100() => TryToSpend(100);
        [ContextMenu("Spend1000")]
        public void Spend1000() => TryToSpend(1000);
#endif
    }
}

