using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class RunningText : MonoBehaviour
{
    public InputActionReference input;
    public SceneScriptable Scene;
    public TextMeshProUGUI dialoguetext;
    public TextMeshProUGUI nama;
    private bool inrange;
    public GameObject canvas;
    public Image img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        
    }

    IEnumerator RunningNPC()
    {
        canvas.SetActive(true);
        input.action.Disable();
        for (int i = 0; i < Scene.Dialog.Count; i++)
        {
            img.sprite = Scene.Dialog[i].Speaker.img;
            nama.text = Scene.Dialog[i].Speaker.nama;
            String conversiation = Scene.Dialog[i].Dialogue;
            dialoguetext.text = "";
            for (int j = 0; j < conversiation.Length; j++)
            {
                dialoguetext.text += conversiation[j];
            yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(1f);
        }
        input.action.Enable();
        canvas.SetActive(false);
    }

    void OnEnable()
    {
        input.action.performed += singletap;
        input.action.Enable();
    }

    void OnDisable()
    {
        input.action.performed -= singletap;
    }
    void singletap(InputAction.CallbackContext context)
    {
        if (inrange)
        {
            Debug.Log("Tap tap");
            StartCoroutine(RunningNPC());
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(inrange);
        if (collision.CompareTag("Player"))
        {
            inrange = true;
            Debug.Log(inrange);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
                Debug.Log(inrange);
        if (collision.CompareTag("Player"))
        {
            inrange = false;
            Debug.Log(inrange);
        }
    }
}
