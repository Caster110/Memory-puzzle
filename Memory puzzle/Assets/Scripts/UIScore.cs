using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class UIScore : MonoBehaviour
{
    [SerializeField] private GameObject highScoreNotification;
    [SerializeField] private GameObject finalScorePanel;
    [SerializeField] private TMP_Text inGameScore;
    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private Button closeFinalScore;
    private Score score;
    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            Initialize();
        else
            YandexGame.GetDataEvent += Initialize;
    }
    private void Initialize()
    {
        YandexGame.GetDataEvent -= Initialize;
        score = new Score();
        EventBus.OnStagePassed += ChangeInGameScore;
        EventBus.OnGameStarted += ChangeInGameScore;
        EventBus.OnGameFailed += ShowFinalScore;
        closeFinalScore.onClick.AddListener(HideFinalScore);
    }
    private void ChangeInGameScore()
    {
        inGameScore.text = score.value.ToString();
    }
    private void ShowFinalScore()
    {
        finalScorePanel.SetActive(true);
        finalScore.text = score.value.ToString();
        if (score.isNewHighScore)
            highScoreNotification.SetActive(true);
    }
    private void HideFinalScore()
    {
        highScoreNotification.SetActive(false);
        finalScorePanel.SetActive(false);
    }
}
