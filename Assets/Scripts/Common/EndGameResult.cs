public class EndGameResult {
    private Mode _gameMode;
    private int _finalScore;

    public Mode GameMode => _gameMode;
    public int FinalScore => _finalScore;

    public EndGameResult(Mode gameMode, int finalScore) {
        _gameMode = gameMode;
        _finalScore = finalScore;
    }
}
