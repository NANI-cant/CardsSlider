using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace StartMenu {
    public class Bank : MonoBehaviour {
        public UnityAction<int> OnEarn;
        public UnityAction<int> OnSpend;

        private int _amount;
        private PlayerProgress _progress;

        public int Amount => _amount;

        [Inject]
        public void Construct(PlayerProgress progress) {
            _progress = progress;
            _amount = _progress.GetBank();
        }

        public bool CanSpend(int total) {
            return _amount >= total;
        }

        public bool TryToSpend(int total) {
            if (!CanSpend(total)) return false;

            _amount -= total;
            _progress.SaveBank(_amount);
            OnSpend?.Invoke(Amount);
            return true;
        }

        public void Earn(int total) {
            _amount += total;
            _progress.SaveBank(_amount);
            OnEarn?.Invoke(Amount);
        }

#if UNITY_EDITOR
        [ContextMenu("Earn 10")]
        public void Earn10() => Earn(10);
        [ContextMenu("Earn 100")]
        public void Earn100() => Earn(100);
        [ContextMenu("Earn 1000")]
        public void Earn1000() => Earn(1000);

        [ContextMenu("Spend 10")]
        public void Spend10() => TryToSpend(10);
        [ContextMenu("Spend 100")]
        public void Spend100() => TryToSpend(100);
        [ContextMenu("Spend 1000")]
        public void Spend1000() => TryToSpend(1000);
#endif
    }
}

