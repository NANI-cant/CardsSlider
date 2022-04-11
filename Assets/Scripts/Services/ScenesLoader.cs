using IJunior.TypedScenes;

public class ScenesLoader {
    private Mode _gameMode;
    private ScoreCounter _score;

    public ScenesLoader(Mode gameMode, ScoreCounter scoreCounter) {
        _gameMode = gameMode;
        _score = scoreCounter;
    }

    public void LoadMenu() {
        EndGameResult endGameResult = new EndGameResult(_gameMode, _score.Score);
        MainMenu.Load(endGameResult);
    }
}
