using TMPro;
using UnityEngine;
using YG;
public class HighScoreDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text normalDifficulty;
    [SerializeField] private TMP_Text hardDifficulty;
    [SerializeField] private TMP_Text impossibleDifficulty;
    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            Initialize();
        else
            YandexGame.GetDataEvent += Initialize;
    }
    private void Initialize()
    {
        normalDifficulty.text = YandexGame.savesData.HighScore[Difficulty.Names.Normal].ToString();
        hardDifficulty.text = YandexGame.savesData.HighScore[Difficulty.Names.Hard].ToString();
        impossibleDifficulty.text = YandexGame.savesData.HighScore[Difficulty.Names.Impossible].ToString();
    }
}
