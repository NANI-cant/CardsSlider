using IJunior.TypedScenes;
using UnityEngine;

namespace StartMenu {
    public class StartMenuEntryPoint : MonoBehaviour, ISceneLoadHandler<EndGameResult> {

        public void OnSceneLoaded(EndGameResult result) {
            foreach (GameModePanel panel in FindObjectsOfType<GameModePanel>()) {
                if (panel.GameMode == result.GameMode) {
                    panel.UpdateBestScore(result.FinalScore);
                }
            }
        }
    }
}
