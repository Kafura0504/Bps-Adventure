using UnityEngine;

public enum audiostate
{
    menu,
    ingame
}
public class dontdestroyaudio : MonoBehaviour
{
    private audiostate state;
    public static dontdestroyaudio instance;
    public audiohandler audioclips;
    public AudioSource source;
    public bool isfirst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);   // Destroy the NEW duplicate
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (isfirst)
        {
            state=audiostate.menu;
            isfirst = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetState(audiostate newState)
    {
        state = newState;

        switch (state)
        {
            case audiostate.menu:
                source.clip = audioclips.audio[0];
                break;

            case audiostate.ingame:
                source.clip = audioclips.audio[1];
                break;


        }

        source.Play();
    }
}
