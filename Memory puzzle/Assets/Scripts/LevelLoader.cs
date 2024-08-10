using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button normalDifficulty;
    [SerializeField] private Button hardDifficulty;
    [SerializeField] private Button impossibleDifficulty;
    private void Awake()
    {
        normalDifficulty.onClick.AddListener(() => LoadLevel(Difficulty.Names.Normal));
        hardDifficulty.onClick.AddListener(() => LoadLevel(Difficulty.Names.Hard));
        impossibleDifficulty.onClick.AddListener(() => LoadLevel(Difficulty.Names.Impossible));
    }
    private void LoadLevel(Difficulty.Names difficulty)
    {
        Difficulty.Current = difficulty;
        SceneManager.LoadScene("Game");
    }
}
