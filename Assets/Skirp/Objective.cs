using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public static Objective instance;
    public int objective;
    public GameObject canvas;
    public SceneScriptable SceneZero;
    public SceneScriptable SceneOne;
    public SceneScriptable SceneEnding;
    public TextMeshProUGUI nama;
    public TextMeshProUGUI dialoguetext;
    public Image img;
    public controller move;
    private int ending;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (objective < 1)
            {
                StartCoroutine(RunningNPC(SceneZero));
            }
            else if (objective>=1 && objective<23)
            {
                StartCoroutine(RunningNPC(SceneOne));
                ending =0;
            }
            else
            {
                StartCoroutine(RunningNPC(SceneEnding));
                ending = 1;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (objective < 1)
            {
                move.input.action.Disable();
                move.move.y = 0;
                move.move.x = 1;
            }
    }
}
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        move.input.action.Enable();
    }
    }
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
    }
    IEnumerator RunningNPC(SceneScriptable Scene)
    {
        canvas.SetActive(true);
        for (int i = 0; i < Scene.Dialog.Count; i++)
        {
            img.sprite = Scene.Dialog[i].Speaker.img;
            nama.text = Scene.Dialog[i].Speaker.nama;
            string conversiation = Scene.Dialog[i].Dialogue;
            dialoguetext.text = "";
            for (int j = 0; j < conversiation.Length; j++)
            {
                dialoguetext.text += conversiation[j];
            yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(1f);
        }
        canvas.SetActive(false);
    }
}
