using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;

namespace StartMenu {
    public class StartMenuEntryPoint : MonoBehaviour, ISceneLoadHandler<EndGameResult> {

        public void OnSceneLoaded(EndGameResult result) {
            foreach (GameModePanel panel in FindObjectsOfType<GameModePanel>()) {
                if (panel.GameMode == result.GameMode) {
                    panel.TryToUpdateBestScore(result.FinalScore);
                }
            }
        }
    }
}
