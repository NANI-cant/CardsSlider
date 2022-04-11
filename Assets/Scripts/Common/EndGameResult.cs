public class EndGameResult {
    private GameMode _gameMode;
    private int _finalScore;

    public GameMode GameMode => _gameMode;
    public int FinalScore => _finalScore;

    public EndGameResult(GameMode gameMode, int finalScore) {
        _gameMode = gameMode;
        _finalScore = finalScore;
    }
}
