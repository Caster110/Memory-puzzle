using UnityEngine;
public class SoundPlayer : MonoBehaviour
{
    //[SerializeField] private A ������ ���� ����������
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

