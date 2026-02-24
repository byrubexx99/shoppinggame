using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource MusicSource;
    public AudioClip TitleMusic;
    public AudioClip GameMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Title":
                MusicSource.volume = 0.5f;
                ChangeMusic(TitleMusic);
                break;
            case "Gameplay":
                MusicSource.volume = 0.2f;
                ChangeMusic(GameMusic);
                break;
        }
    }

    private void ChangeMusic(AudioClip newClip)
    {
        if (MusicSource.clip == newClip) return;

        MusicSource.clip = newClip;
        MusicSource.Play();
    }
}
