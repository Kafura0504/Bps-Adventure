using UnityEngine;
using UnityEngine.SceneManagement;

public enum audiostate
{
    menu,
    ingame,
    story,
    ending
}

public class dontdestroyaudio : MonoBehaviour
{
    private audiostate state;
    public static dontdestroyaudio instance;
    public audiohandler audioclips;
    public AudioSource source;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneChanged;

        UpdateStateFromSceneIndex(SceneManager.GetActiveScene().buildIndex);
        SetState();
    }

    void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        UpdateStateFromSceneIndex(newScene.buildIndex);
        SetState();
    }

    void UpdateStateFromSceneIndex(int index)
    {
        switch (index)
        {
            case 0:
                state = audiostate.menu;
                break;
            case 1:
                state = audiostate.story;
                break;
            case 2:
                state = audiostate.ingame;
                break;
            case 3:
                state = audiostate.ending;
                break;
        }
    }

    public void SetState()
    {
        switch (state)
        {
            case audiostate.menu:
                source.clip = audioclips.audio[0];
                break;

            case audiostate.ingame:
                source.clip = audioclips.audio[1];
                break;

            case audiostate.story:
                source.clip = audioclips.audio[2];
                break;

            case audiostate.ending:
                source.clip = audioclips.audio[3];
                break;
        }

        source.Play();
    }
}
