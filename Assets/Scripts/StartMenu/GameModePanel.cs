using IJunior.TypedScenes;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartMenu {
    public class GameModePanel : MonoBehaviour {
        [SerializeField] private GameMode _gameMode = GameMode.Classic;
        [SerializeField] private LocalizedText _bestScoreLabel;
        [SerializeField] private TextMeshProUGUI _bestScoreUI;
        [SerializeField] private string NewBestLocalizationKey = "NewBestScoreLabel";
        [SerializeField] private string BestLocalizationKey = "BestScoreLabel";

        private int _bestScore;
        private PlayerProgress _progress;

        public GameMode GameMode => _gameMode;

        [Inject]
        public void Construct(PlayerProgress progress) {
            _progress = progress;
            UpdateBestScore(_progress.GetScore(_gameMode));
        }

        public void Play() {
            switch (_gameMode) {
                case GameMode.Classic: {
                        Classic.Load();
                        break;
                    }
                default: {
                        break;
                    }
            }
        }

        public void UpdateBestScore(int finalScore) {
            bool isNewBest = _progress.TryUpdateScore(_gameMode, finalScore, out _bestScore);
            ChangeBestScoreUI(isNewBest);
        }

        private void ChangeBestScoreUI(bool isNewBest) {
            if (isNewBest) {
                _bestScoreLabel.SetKey(NewBestLocalizationKey);
            }
            else {
                _bestScoreLabel.SetKey(BestLocalizationKey);
            }
            _bestScoreUI.text = _bestScore.ToString();
        }
    }
}
