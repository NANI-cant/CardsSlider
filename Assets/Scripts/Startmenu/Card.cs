using IJunior.TypedScenes;
using TMPro;
using UnityEngine;

namespace StartMenu {
    public class Card : MonoBehaviour {
        [SerializeField] private Mode _gameMode = Mode.Classic;

        [SerializeField] private LocalizedText _bestScoreLabel;
        [SerializeField] private TextMeshProUGUI _bestScoreUI;
        private int? _bestScore;

        public Mode GameMode => _gameMode;

        private void Start() {
            if (_bestScore == null) {
                TryToUpdateBestScore(-1);
            }
        }

        public void Play() {
            switch (_gameMode) {
                case Mode.Classic: {
                        Classic.Load();
                        break;
                    }
                default: {
                        break;
                    }
            }
        }

        public bool TryToUpdateBestScore(int finalScore) {
            _bestScore = PlayerPrefs.GetInt(SaveKey.ClassicScore, 0);
            if (finalScore <= _bestScore) {
                ChangeBestScoreUI(false);
                return false;
            }

            _bestScore = finalScore;
            PlayerPrefs.SetInt(SaveKey.ClassicScore, (int)_bestScore);
            ChangeBestScoreUI(true);
            return true;
        }

        private void ChangeBestScoreUI(bool isNewBest) {
            if (isNewBest) {
                _bestScoreLabel.SetKey(LocalizationKey.NewBestScoreLabel);
            }
            else {
                _bestScoreLabel.SetKey(LocalizationKey.BestScoreLabel);
            }
            _bestScoreUI.text = _bestScore.ToString();
        }
    }
}
