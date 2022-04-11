using IJunior.TypedScenes;

public class ScenesLoader {
    private GameMode _gameMode;
    private ScoreCounter _score;

    public ScenesLoader(GameMode gameMode, ScoreCounter scoreCounter) {
        _gameMode = gameMode;
        _score = scoreCounter;
    }

    public void LoadMenu() {
        EndGameResult endGameResult = new EndGameResult(_gameMode, _score.Score);
        MainMenu.Load(endGameResult);
    }
}
