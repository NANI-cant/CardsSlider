using UnityEngine;

namespace StartMenu {
    public class MenuExitView : MonoBehaviour {
        [SerializeField] private MovableCardFigure _cardFigure;
        [SerializeField] private Fade[] _canvasesFade;
        [SerializeField] private MovableFigure[] _figures;

        public void Animate() {
            foreach (Fade canvasFade in _canvasesFade) {
                canvasFade.Hide();
            }
            MoveFigures();
        }

        private void MoveFigures() {
            _cardFigure.AnimateSceneExit();
            foreach (MovableFigure figure in _figures) {
                figure.MoveOutOfBorder();
            }
        }
    }
}
