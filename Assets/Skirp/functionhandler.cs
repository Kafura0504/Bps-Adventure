using UnityEngine;
using UnityEngine.SceneManagement;
public class functionhandler : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
        dontdestroyaudio.instance.SetState(audiostate.ingame);
    }
    public void quit()
    {
        Application.Quit();
    }
}
