using System.Collections;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject canvas;
    public Image img;
     public SceneScriptable[] Scene;
    public TextMeshProUGUI dialoguetext;
    public TextMeshProUGUI nama;
    public int index =0;
    public int Nextsceneindex;
    private AsyncOperation load;
    public bool isstart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isstart)
        {   
         load = SceneManager.LoadSceneAsync(Nextsceneindex);
         load.allowSceneActivation = false;
         StartCoroutine(RunningNPC(Scene[index]));
        }
        else
        {
        
        load = SceneManager.LoadSceneAsync(Nextsceneindex);
         load.allowSceneActivation = false;
         StartCoroutine(RunningNPC(Scene[Objective.instance.ending]));
        }
    }
        IEnumerator RunningNPC(SceneScriptable adegan)
        {
            canvas.SetActive(true);
            for (int i = 0; i < adegan.Dialog.Count; i++)
            {
                if (adegan.Dialog[i].Speaker==null)
                    {
                        img.sprite = null;
                        img.gameObject.SetActive(false);
                        nama.gameObject.SetActive(false);
                    }
                    else
                    {
                        img.gameObject.SetActive(true);
                        nama.gameObject.SetActive(true);
                        img.sprite = adegan.Dialog[i].Speaker.img;
                        nama.text = adegan.Dialog[i].Speaker.nama;
                    }
                string conversiation = adegan.Dialog[i].Dialogue;
                dialoguetext.text = "";
                for (int j = 0; j < conversiation.Length; j++)
                {
                    dialoguetext.text += conversiation[j];
                yield return new WaitForSeconds(0.03f);
                }
                yield return new WaitForSeconds(2f);
            }
            load.allowSceneActivation=true;
        }

    

}
