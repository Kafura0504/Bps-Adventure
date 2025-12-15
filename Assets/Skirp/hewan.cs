using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class hewan : MonoBehaviour
{
    public Animalscriptable animal;
    public bool inrange;
    public TextMeshProUGUI dialoguetext;
    public TextMeshProUGUI nama;
    public GameObject canvas;
    public InputActionReference input;
    public SpeakerScriptable speaker;
    public Image imageholder;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI esmosi;
    public TextMeshProUGUI height;
    private bool done;
    public Objective tujuan;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {      
          inrange=true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {    
        inrange=false;
        }
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

    void Update()
    {

    }

    IEnumerator RunningNPC()
    {
        if (!done)
        {
            done = true;
            tujuan.objective += 1;
        }
        canvas.SetActive(true);
        input.action.Disable();
        height.text = animal.height.ToString();
        weight.text = animal.weight.ToString();
        esmosi.text = animal.esmosi.ToString();
            imageholder.sprite =speaker.img;
            nama.text = speaker.nama;
            string conversiation = "Hmmmmm hewan ini punya berat "+animal.weight+"Kg. dan tingginya sekitar... "+animal.height+" meter. Dan, Wih moodnya "+animal.esmosi+" bisa gitu ya...";
            dialoguetext.text = "";
            for (int j = 0; j < conversiation.Length; j++)
            {
                dialoguetext.text += conversiation[j];
            yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(1f);
            input.action.Enable();
        canvas.SetActive(false);
    }
}
