using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;

namespace StartMenu {
    public class UIManager : MonoBehaviour, ISceneLoadHandler<EndGameResult> {

        public void OnSceneLoaded(EndGameResult result) {
            foreach (Card card in GetComponentsInChildren<Card>()) {
                if (card.GameMode == result.GameMode) {
                    card.TryToUpdateBestScore(result.FinalScore);
                }
            }
        }
    }
}
