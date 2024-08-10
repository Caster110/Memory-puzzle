using UnityEngine;
public class SoundPlayer : MonoBehaviour
{
    //[SerializeField] private A короче Влад разбирайся
    public static SoundPlayer Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

