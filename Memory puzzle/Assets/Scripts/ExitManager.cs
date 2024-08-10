using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitManager : MonoBehaviour
{
    [SerializeField] private GameObject notification;
    [SerializeField] private Button exit;
    [SerializeField] private Button confimation;
    [SerializeField] private Button refusal;
    private void Awake()
    {
        exit.onClick.AddListener(EnableConfirmation);
    }
    private void EnableConfirmation()
    {
        notification.SetActive(true);
        exit.onClick.RemoveAllListeners();
        confimation.onClick.AddListener(Exit);
        refusal.onClick.AddListener(HandleRefuse);
    }
    private void HandleRefuse()
    {
        notification.SetActive(false);
        exit.onClick.AddListener(EnableConfirmation);
        confimation.onClick.RemoveAllListeners();
        refusal.onClick.RemoveAllListeners();
    }
    private void Exit()
    {
        EventBus.RemoveAllListeners();
        SceneManager.LoadScene("MainMenu");
    }
}
