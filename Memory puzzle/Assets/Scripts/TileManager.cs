using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class TileManager : MonoBehaviour
{
    [SerializeField] private Difficulty.Names difficulty;
    [SerializeField] private Tile[] tiles;
    [SerializeField] private Button adForShowSolution;
    [SerializeField] private Button adForContinue;
    [SerializeField] private Button restartGame;
    //[SerializeField] private AudioClip lossSound;
    private Coroutine solutionCoroutine;
    private System.Random random;
    private int currentStepIndex;
    private int tilesLength;
    private int[] solution;
    private void Awake()
    {
        if (difficulty != Difficulty.Current)
        {
            Destroy(gameObject); // мейби отключение
            return;
        }

        if (YandexGame.SDKEnabled)
            Initialize();
        else
            YandexGame.GetDataEvent += Initialize;
    }
    private void Initialize()
    {
        YandexGame.GetDataEvent -= Initialize;
        tilesLength = tiles.Length;
        random = new System.Random();
        EventBus.OnTileClicked += HandleClick;
        YandexGame.RewardVideoEvent += GiveReward;
        adForShowSolution.onClick.AddListener(() => YandexGame.RewVideoShow(0));
        adForContinue.onClick.AddListener(() => YandexGame.RewVideoShow(1));
        restartGame.onClick.AddListener(StartNewGame);
        StartNewGame();
    }
    private void ContinueGame()
    {
        //EventBus.OnGameStarted?.Invoke();
        ShowSolution(currentStepIndex);
    }
    private void StartNewGame()
    {
        EventBus.OnGameStarted?.Invoke();
        currentStepIndex = 0;
        solution = new int[0];
        GenerateSolution();
        ShowSolution(currentStepIndex);
    }
    private void HandleClick(Tile tile)
    {
        bool isRightAnswer = tiles[solution[currentStepIndex]] == tile;
        if (isRightAnswer)
        {
            //tile.ClickSound play or smth
            currentStepIndex++;
            if (currentStepIndex == solution.Length)
            {
                EventBus.OnStagePassed?.Invoke();
                GenerateSolution();
                ShowSolution(currentStepIndex);
            }
        }
        else
        {
            EventBus.OnGameFailed?.Invoke();
        }
    }
    private void GenerateSolution()
    {
        int oldSolutionLength = solution.Length;
        int[] newSolution = new int[oldSolutionLength + 1];
        for (int i = 0; i < oldSolutionLength; i++)
        {
            newSolution[i] = solution[i];
        }
        newSolution[oldSolutionLength] = random.Next(0, tilesLength);
        solution = newSolution;
    }
    private void ShowSolution(int fromStep)
    {
        if (solutionCoroutine != null)
            StopCoroutine(solutionCoroutine);
        solutionCoroutine = StartCoroutine(HighliteSolution(fromStep));
    }
    private IEnumerator HighliteSolution(int fromStep)
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = fromStep; i < solution.Length; i++)
        {
            tiles[solution[i]].Light();
            yield return new WaitForSeconds(0.1f);
        }
        EventBus.OnSolutionShown?.Invoke();
        solutionCoroutine = null;
    }
    private void GiveReward(int index)
    {
        if (index == 0)
            ShowSolution(currentStepIndex);
        else
            ContinueGame();
    }
}
