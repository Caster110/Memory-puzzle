using YG;
public class Score
{
    public int value { get; private set; }
    public int best { get; private set; }
    public bool isNewHighScore { get; private set; }
    public Score()
    {
        best = YandexGame.savesData.HighScore[Difficulty.Current];
        EventBus.OnGameFailed += TrySetHighScore;
        EventBus.OnStagePassed += Insrease;
        EventBus.OnGameStarted += Reset;
    }
    private void TrySetHighScore()
    {
        isNewHighScore = value > best;
        if (isNewHighScore)
        {
            best = value;
            YandexGame.NewLeaderboardScores(Difficulty.Current.ToString(), best);
            YandexGame.savesData.HighScore[Difficulty.Current] = best;
            YandexGame.SaveProgress();
        }
    }
    private void Insrease()
    {
        value++;
    }
    public void Reset()
    {
        value = 0;
    }
}