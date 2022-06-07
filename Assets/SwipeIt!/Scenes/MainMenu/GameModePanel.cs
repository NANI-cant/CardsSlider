using IJunior.TypedScenes;
using TMPro;
using UnityEngine;
using Zenject;

namespace StartMenu {
    public class GameModePanel : MonoBehaviour {
        [SerializeField] private GameMode _gameMode = GameMode.Classic;
        [SerializeField] private TextMeshProUGUI _bestScoreUI;

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
            _progress.TryUpdateScore(_gameMode, finalScore, out _bestScore);
            ChangeBestScoreUI();
        }

        private void ChangeBestScoreUI() {
            _bestScoreUI.text = _bestScore.ToString();
        }
    }
}
