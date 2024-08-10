using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private AudioClip clickSound;
    public AudioClip ClickSound => clickSound;
    private void Start()
    {
        ToggleButton(false);
        button.onClick.AddListener(() => EventBus.OnTileClicked?.Invoke(this));
        EventBus.OnGameStarted += () => ToggleButton(true);
        EventBus.OnSolutionShown += () => ToggleButton(true);
        EventBus.OnGameFailed += () => ToggleButton(false);
        EventBus.OnStagePassed += () => ToggleButton(false);
    }
    private void ToggleButton(bool state)
    {
        button.enabled = state;
    }
    public void Light()
    {
        //smth
    }
}
